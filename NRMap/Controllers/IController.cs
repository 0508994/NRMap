using System.Collections.Generic;

namespace NRMap.Controllers
{
    public interface IController
    {
        bool BShowUTM { set; }
        string ActiveLayer { set; }

        void OnMapMouseMoved(GeoAPI.Geometries.Coordinate point);
        void OnMapMouseClick(GeoAPI.Geometries.Coordinate point);
        void OnAddRoadsLayer();
        void OnAddNRLayer(string query=null);
        void OnAddLanduseLayer();

        void OnRemoveLayer(string layerName);

        void OnReturnBBoxFeatures(IList<double[]> bounds);
    }
}
