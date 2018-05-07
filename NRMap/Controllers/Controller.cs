using GeoAPI.CoordinateSystems;
using GeoAPI.CoordinateSystems.Transformations;
using GeoAPI.Geometries;
using NRMap.Views;
using NRMap.Utilities;
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
            if (_view.GetLayerByName(Constants.roadsLayerName) != null)
                return;

            SharpMap.Data.Providers.PostGIS postGisProv = new
                SharpMap.Data.Providers.PostGIS(Constants.connStr, Constants.roadsTable, Constants.geomName, Constants.idName)
            {
                DefinitionQuery = "fclass = 'primary' or fclass = 'secondary' or fclass = 'motorway_link'"
            };

            VectorLayer roadsLayer = new VectorLayer(Constants.roadsLayerName)
            {
                DataSource = postGisProv
            };

            System.Drawing.Pen primaryRoadPen = new System.Drawing.Pen(new System.Drawing.SolidBrush(System.Drawing.Color.Red))
            {
                Width = 1.5f
            };

            Dictionary<string, IStyle> styles = new Dictionary<string, IStyle>()
            {
                { "primary", new VectorStyle() { Line = primaryRoadPen } },
                { "secondary", new VectorStyle() { Line = System.Drawing.Pens.Orange } },
                { "motorway_link", new VectorStyle() { Line = System.Drawing.Pens.Olive } }
            };

            roadsLayer.Theme = new SharpMap.Rendering.Thematics.UniqueValuesTheme<string>("fclass",
                    styles, null);

            LabelLayer roadLabel = new LabelLayer(Constants.roadsLabelName)
            {
                DataSource = roadsLayer.DataSource,
                Enabled = true,
                LabelColumn = "name",
                MaxVisible = 0.3f
            };

            //SetCtAndRct(roadsLayer);
            //SetCtAndRct(roadLabel);

            _view.AddLayer(roadsLayer);
            _view.AddLayer(roadLabel);
        }

        public void OnAddNRLayer()
        {
            if (_view.GetLayerByName(Constants.nrLayerName) != null)
                return;

            SharpMap.Data.Providers.PostGIS postGisProv = new
                SharpMap.Data.Providers.PostGIS(Constants.connStr, Constants.nrTable, Constants.geomName, Constants.idName);

            VectorLayer nrLayer = new VectorLayer(Constants.nrLayerName)
            {
                DataSource = postGisProv
            };

            // Define style for each fclass of natural resource
            Dictionary<string, IStyle> styles = new Dictionary<string, IStyle>()
            {
                { "cave_entrance", new VectorStyle() { Symbol = Properties.Resources.cave } },
                { "tree", new VectorStyle() { Symbol = Properties.Resources.tree, SymbolScale = 0.8f } },
                { "peak", new VectorStyle() { Symbol = Properties.Resources.peak, SymbolScale = 0.7f } },
                { "spring", new VectorStyle() { Symbol = Properties.Resources.water } },
                { "beach", new VectorStyle() { Symbol = Properties.Resources.beach } },
                { "cliff", new VectorStyle() { Symbol = Properties.Resources.cliff  } }
            };

            nrLayer.Theme = new SharpMap.Rendering.Thematics.UniqueValuesTheme<string>("fclass",
                    styles, null);

            LabelLayer nrLabel = new LabelLayer(Constants.nrLabelName)
            {
                DataSource = nrLayer.DataSource,
                Enabled = true,
                LabelColumn = "name",
                MaxVisible = 0.3f
            };

            //SetCtAndRct(nrLayer);
            //SetCtAndRct(nrLabel);

            _view.AddLayer(nrLayer);
            _view.AddLayer(nrLabel);
        }

        public void OnAddWatersLayer()
        {
            if (_view.GetLayerByName(Constants.watersLayerName) != null)
                return;

            SharpMap.Data.Providers.PostGIS postGisProv = new
                SharpMap.Data.Providers.PostGIS(Constants.connStr, Constants.watersTable, Constants.geomName, Constants.idName);

            VectorLayer watersLayer = new VectorLayer(Constants.watersLayerName)
            {
                DataSource = postGisProv
            };

            System.Drawing.Brush riverBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(59, 179, 208));
            System.Drawing.Brush wetlandBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(59, 151, 128));
            System.Drawing.Brush dockBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(164, 164, 132));
            System.Drawing.Brush reservoirBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 132, 255));
            System.Drawing.Brush waterBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(64, 164, 223));

            Dictionary<string, IStyle> styles = new Dictionary<string, IStyle>()
            {
                { "wetland", new VectorStyle() { Fill = wetlandBrush } },
                { "reservoir", new VectorStyle() { Fill = reservoirBrush } },
                { "dock", new VectorStyle() { Fill = dockBrush } },
                { "river", new VectorStyle() { Fill = riverBrush } },
                { "water", new VectorStyle() { Fill = waterBrush } }
            };

            watersLayer.Theme = new SharpMap.Rendering.Thematics.UniqueValuesTheme<string>("fclass",
                styles, null);

            LabelLayer watersLabel = new LabelLayer(Constants.watersLabelName)
            {
                DataSource = watersLayer.DataSource,
                Enabled = true,
                LabelColumn = "name",
                MaxVisible = 0.3f
            };

            //SetCtAndRct(watersLayer);
            //SetCtAndRct(watersLabel);

            _view.AddLayer(watersLayer);
            _view.AddLayer(watersLabel);
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

            Envelope envelope = new Envelope(point.X, point.X + 0.014f, point.Y, point.Y - 0.013f);

            GetEnvelopeIntersections(envelope);
        }

        public void OnReturnBBoxFeatures(IList<double[]> bounds)
        {
            //bounds = TransformCords(bounds);
            double[] topLeft = bounds[0];
            double[] bottomRight = bounds[1];

            Envelope bbox = new Envelope(topLeft[0], bottomRight[0], topLeft[1], bottomRight[1]);

            GetEnvelopeIntersections(bbox);
        }

        public void OnQueryLayer(string query, System.Drawing.Color resultColor)
        {
            // Create the postGis provider object, and init it's query property with the passed query
            SharpMap.Data.Providers.PostGIS postGisProv = new
                SharpMap.Data.Providers.PostGIS(Constants.connStr, _activeLayer, Constants.geomName, Constants.idName)
            {
                DefinitionQuery = query
            };

            SharpMap.Rendering.Thematics.ITheme theme = null;
            System.Drawing.Brush queryResultBrush = new System.Drawing.SolidBrush(resultColor);

            // Create a theme based on the active layer
            if (_activeLayer == Constants.roadsTable)
            {
                System.Drawing.Pen queryResultPen = new System.Drawing.Pen(queryResultBrush);
                theme = new SharpMap.Rendering.Thematics.CustomTheme( (SharpMap.Data.FeatureDataRow fdr)
                    => { return new VectorStyle() { Line = queryResultPen }; } );
            }
            else if (_activeLayer == Constants.nrTable)
            {
                theme = new SharpMap.Rendering.Thematics.CustomTheme( (SharpMap.Data.FeatureDataRow fdr)
                    => { return new VectorStyle() { PointColor = queryResultBrush, PointSize = 3f }; } );
            }
            else
            {
                theme = new SharpMap.Rendering.Thematics.CustomTheme( (SharpMap.Data.FeatureDataRow fdr)
                    => { return new VectorStyle() { Fill = queryResultBrush }; } );
            }

            // Create the resulting vector layer object for query result, and set the created theme
            VectorLayer resultingLayer = new VectorLayer(Constants.queryLayerName)
            {
                DataSource = postGisProv,
                Theme = theme
            };

            // Create label of the results
            LabelLayer resultingLabel = new LabelLayer(Constants.queryLabelName)
            {
                DataSource = resultingLayer.DataSource,
                Enabled = true,
                LabelColumn = "name",
                MaxVisible = 0.3f
            };

            try
            {
                // NPGSQL exception handle ruins the map by returning an empty layer
                // Getting an envelope when query is invalid triggers an exception
                SharpMap.Data.FeatureDataSet fds = new SharpMap.Data.FeatureDataSet();
                postGisProv.Open();
                Envelope envelope = resultingLayer.Envelope; // <----- Exception
                postGisProv.ExecuteIntersectionQuery(envelope, fds);
                postGisProv.Close();

                // Remove the previous query result if it exists
                OnRemoveLayer(Constants.queryLayerName);
                OnRemoveLayer(Constants.queryLabelName);

                // Add the results to the map
                _view.AddLayer(resultingLayer);
                _view.AddLayer(resultingLabel);
                _view.DataGridView = fds.Tables[0];
            }
            catch (System.Exception e)
            {
                System.Console.Write(e.Message);
                return;
            }
        }
        #endregion
    }
}
