namespace NRMap.Controllers
{
    public interface IController
    {
        bool BShowUTM { set; }

        void OnMapMouseMoved(GeoAPI.Geometries.Coordinate point);
        void OnAddRoadsLayer();

        void OnRemoveLayer(string layerName);
    }
}
