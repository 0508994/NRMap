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

        // TODO:
        void OnAdvanceQuery(string sourceTable, string targetTable, string definitionQuery,
            System.Drawing.Color resultColor, int opCode, System.Collections.Generic.IList<double> additionalParams);
    }
}
