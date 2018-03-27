using GeoAPI.CoordinateSystems;
using GeoAPI.CoordinateSystems.Transformations;
using GeoAPI.Geometries;
using NRMap.Views;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRMap.Controllers
{
    public class Controller : IController
    {
        private IView _view;
        private bool _bShowUTM;

        public Controller(IView view)
        {
            _view = view;
            _view.AddListener(this);
        }

        public bool BShowUTM
        {
            set
            {
                _bShowUTM = value;
            }
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

            _view.TextCoord = "X: " + point.X + "   Y: " + point.Y;
        }

    }
}
