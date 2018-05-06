using GeoAPI.CoordinateSystems;
using GeoAPI.CoordinateSystems.Transformations;
using GeoAPI.Geometries;
using NRMap.Views;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using System.Collections.Generic;
using SharpMap.Layers;
using SharpMap.Styles;

namespace NRMap.Controllers
{
    /// <summary>
    /// Class containing all aplication logic
    /// </summary>
    public class Controller : IController
    {
        #region Attributes and Properties
        private IView _view;
        // show real or UTM coordinates indicator
        private bool _bShowUTM;
        // Active Query layer
        private string _activeLayer = Constants.roadsTable; // TODO:

        public bool BShowUTM
        {
            set
            {
                _bShowUTM = value;
            }
        }
        
        public string ActiveLayer
        {
            set
            {
                _activeLayer = value;
            }
        }
        #endregion

        public Controller(IView view)
        {
            _view = view;
            _view.AddListener(this);
        }

        #region Private Methods
        // Set coordinate transformation and reverse coordinate transformation of a given layer (Only if using BruTile background layer)
        private void SetCtAndRct(Layer layer)
        {
            CoordinateTransformationFactory cFact = new CoordinateTransformationFactory();
            layer.CoordinateTransformation =
                cFact.CreateFromCoordinateSystems(GeographicCoordinateSystem.WGS84, ProjectedCoordinateSystem.WebMercator);
            layer.ReverseCoordinateTransformation =
                cFact.CreateFromCoordinateSystems(ProjectedCoordinateSystem.WebMercator, GeographicCoordinateSystem.WGS84);

            //double[] a = { 1.0, 2.0, 3.0 };
            //layer.CoordinateTransformation.MathTransform.Transform(a);
        }

        // Coordinate transformation WebMercator <-> WGS84 (based on reverse param) (Only if using BruTile background layer)
        private IList<double[]> TransformCords(IList<double[]> coordinates, bool reverse=true)
        {
            CoordinateTransformationFactory cFact = new CoordinateTransformationFactory();
            ICoordinateTransformation cTrans = null;
            if (reverse)
                cTrans = cFact.CreateFromCoordinateSystems(ProjectedCoordinateSystem.WebMercator, GeographicCoordinateSystem.WGS84);
            else
                cTrans = cFact.CreateFromCoordinateSystems(GeographicCoordinateSystem.WGS84, ProjectedCoordinateSystem.WebMercator);

            return cTrans.MathTransform.TransformList(coordinates);
        }

        // GIS RV09 - Slide 4
        private IProjectedCoordinateSystem CreateUtmProjection(int utmZone)
        {
            CoordinateSystemFactory cFac = new CoordinateSystemFactory();

            // Create geographic coordinate system based on the WGS84 datum
            IEllipsoid ellipsoid = cFac.CreateFlattenedSphere("WGS 84", 6378137, 298.257223563, LinearUnit.Metre);
            IHorizontalDatum datum = cFac.CreateHorizontalDatum("WGS 84", DatumType.HD_Geocentric, ellipsoid, null);
            IGeographicCoordinateSystem gcs = cFac.CreateGeographicCoordinateSystem("WGS 84", AngularUnit.Degrees, datum,
                PrimeMeridian.Greenwich, new AxisInfo("Lon", AxisOrientationEnum.East),
                new AxisInfo("Lat", AxisOrientationEnum.North));

            // Create UTM projection
            List<ProjectionParameter> parameters = new List<ProjectionParameter>();
            parameters.Add(new ProjectionParameter("latitude_of_origin", 0));
            parameters.Add(new ProjectionParameter("central_meridian", -183 + 6 * utmZone));
            parameters.Add(new ProjectionParameter("scale_factor", 0.9996));
            parameters.Add(new ProjectionParameter("false_easting", 500000));
            parameters.Add(new ProjectionParameter("false_northing", 0.0));
            IProjection projection = cFac.CreateProjection("Transverse Mercator", "Transverse_Mercator", parameters);

            return cFac.CreateProjectedCoordinateSystem("WGS 84 / UTM zone " + utmZone.ToString() + "N", gcs,
                projection, LinearUnit.Metre, new AxisInfo("East", AxisOrientationEnum.East),
                new AxisInfo("Norh", AxisOrientationEnum.North));
        }

        // Get thematic features whose geoms intersect with the passed envelope
        private void GetEnvelopeIntersections(Envelope envelope)
        {
            SharpMap.Data.Providers.PostGIS postGisProv = new
                SharpMap.Data.Providers.PostGIS(Constants.connStr, _activeLayer, Constants.geomName, Constants.idName);

            SharpMap.Data.FeatureDataSet fds = new SharpMap.Data.FeatureDataSet();
            postGisProv.Open();
            postGisProv.ExecuteIntersectionQuery(envelope, fds);
            postGisProv.Close();

            //System.Windows.Forms.MessageBox.Show(fds.Tables[0].Rows.Count.ToString());

            _view.DataGridView = fds.Tables[0];
        }

        // NPGSQL EXCEPTION - BAD GEOMETRY FORMATING IN THE RESULTING QUERY && TABLE NAMES MUST BE ALTERED NOT TO CONTAIN ""
        private void GetGeometryIntersections(IGeometry geometry)
        {
            SharpMap.Data.Providers.PostGIS postGisProv = new
                SharpMap.Data.Providers.PostGIS(Constants.connStr, _activeLayer, Constants.geomName, Constants.idName);

            SharpMap.Data.FeatureDataSet fds = new SharpMap.Data.FeatureDataSet();
            postGisProv.Open();
            postGisProv.ExecuteIntersectionQuery(geometry, fds);
            postGisProv.Close();

            //System.Windows.Forms.MessageBox.Show(fds.Tables[0].Rows.Count.ToString());

            _view.DataGridView = fds.Tables[0];
        }
        #endregion

        #region Event Handling
        public void OnMapMouseMoved(Coordinate point)
        {
            if (_bShowUTM)
            {
                IProjectedCoordinateSystem utmProj = CreateUtmProjection(34);
                IGeographicCoordinateSystem geoCS = utmProj.GeographicCoordinateSystem;
                CoordinateTransformationFactory ctFac = new CoordinateTransformationFactory();
                ICoordinateTransformation transform = ctFac.CreateFromCoordinateSystems(geoCS, utmProj);
                double[] coordsGeo = new double[2];
                double[] coordsUTM;
                coordsGeo[0] = point.X;
                coordsGeo[1] = point.Y;
                coordsUTM = transform.MathTransform.Transform(coordsGeo);
                point.X = coordsUTM[0];
                point.Y = coordsUTM[1];
            }

            _view.TextCoord = "X: " + point.X + "  Y: " + point.Y;
        }

        public void OnAddRoadsLayer()
        {
            SharpMap.Data.Providers.PostGIS postGisProv = new
                SharpMap.Data.Providers.PostGIS(Constants.connStr, Constants.roadsTable, Constants.geomName, Constants.idName)
            {
                DefinitionQuery = "fclass = 'primary' or fclass = 'secondary' or fclass = 'motorway_link'"
            };

            VectorLayer roadsLayer = new VectorLayer(Constants.roadsLayerName)
            {
                DataSource = postGisProv
            };

            // style used to render primary roads { fclass = primary }
            VectorStyle primaryRoadStyle = new VectorStyle()
            {
                Line = System.Drawing.Pens.Red
            };

            // style used for rendering secondary roads { fclass = secondary }
            VectorStyle secondaryRoadStyle = new VectorStyle()
            {
                Line = System.Drawing.Pens.Orange
            };

            // style used for rendering motorway links { fclass = motorway_link }
            VectorStyle motorwayLinkStyle = new VectorStyle()
            {
                Line = System.Drawing.Pens.Olive
            };

            Dictionary<string, IStyle> styles = new Dictionary<string, IStyle>
                {
                    { "primary", primaryRoadStyle },
                    { "secondary", secondaryRoadStyle },
                    { "motorway_link", motorwayLinkStyle }
                };

            roadsLayer.Theme = new SharpMap.Rendering.Thematics.UniqueValuesTheme<string>("fclass",
                    styles, null);

            LabelLayer roadLabel = new LabelLayer(Constants.roadsLabelName)
            {
                DataSource = roadsLayer.DataSource,
                Enabled = true,
                LabelColumn = "name"
            };

            //SetCtAndRct(roadsLayer);
            //SetCtAndRct(roadLabel);

            _view.AddLayer(roadsLayer);
            _view.AddLayer(roadLabel);
        }

        public void OnAddNRLayer()
        {
            SharpMap.Data.Providers.PostGIS postGisProv = new
                SharpMap.Data.Providers.PostGIS(Constants.connStr, Constants.nrTable, Constants.geomName, Constants.idName);

            VectorLayer nrLayer = new VectorLayer(Constants.nrLayerName)
            {
                DataSource = postGisProv
            };

            // style used to render cave entrances { fclass = cave_entrance }
            VectorStyle caveEntranceStyle = new VectorStyle()
            {
                Symbol = Properties.Resources.cave
            };



            Dictionary<string, IStyle> styles = new Dictionary<string, IStyle>
                {
                    { "cave_entrance", caveEntranceStyle }
                };

            nrLayer.Theme = new SharpMap.Rendering.Thematics.UniqueValuesTheme<string>("fclass",
                    styles, null);



            _view.AddLayer(nrLayer);
        }

        public void OnAddLanduseLayer()
        {

        }
        
        public void OnRemoveLayer(string layerName)
        {
            ILayer toRemove = _view.GetLayerByName(layerName);
            _view.RemoveLayer(toRemove);
        }

        public void OnMapMouseClick(Coordinate point)
        {
            //CoordinateTransformationFactory cFact = new CoordinateTransformationFactory();
            //ICoordinateTransformation cTrans = cFact.CreateFromCoordinateSystems(ProjectedCoordinateSystem.WebMercator, GeographicCoordinateSystem.WGS84);
            //point = cTrans.MathTransform.Transform(point);

            //IGeometryFactory gFact = new GeometryFactory();
            //IGeometry geom = gFact.CreatePoint(point);

            Envelope geom = new Envelope(point);

            GetEnvelopeIntersections(geom);

        }

        public void OnReturnBBoxFeatures(IList<double[]> bounds)
        {
            //bounds = TransformCords(bounds);
            double[] topLeft = bounds[0];
            double[] bottomRight = bounds[1];

            Envelope bbox = new Envelope(topLeft[0], bottomRight[0], topLeft[1], bottomRight[1]);

            GetEnvelopeIntersections(bbox);
        }
        #endregion


    }
}
