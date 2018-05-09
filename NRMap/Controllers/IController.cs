namespace NRMap.Controllers
{
    public interface IController
    {
        bool BShowUTM { set; }
        string ActiveLayer { set; }

        void OnMapMouseMoved(GeoAPI.Geometries.Coordinate point);
        void OnMapMouseClick(GeoAPI.Geometries.Coordinate point);

        void OnAddRoadsLayer();
        void OnAddNRLayer();
        void OnAddWatersLayer();

        void OnRemoveLayer(string layerName);

        void OnReturnBBoxFeatures(System.Collections.Generic.IList<double[]> bounds);
        void OnQueryLayer(string query, System.Drawing.Color resultColor);

        void OnAdvanceQuery(string sourceTable, string targetTable, string definitionQuery,
            int opCode, double additionalParam);
    }
}
