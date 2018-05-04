namespace NRMap
{
    public static class Constants
    {
        #region DB Constants
        // PostgreSQL database connection String
        public const string connStr = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=milan;Database=srb";
        // Name of the geometry field of each table
        public const string geomName = "geom";
        // Name of the id field of each table
        public const string idName = "gid";
        // Name of the table for the roads layer
        public const string roadsTable = "public.\"gis.osm_roads_free_1\"";
        #endregion

        #region Layer and Label names
        // Name of the roads layer
        public const string roadsLayerName = "Roads";
        // Name of the roads label layer
        public const string roadsLabelName = "RoadsLabels";
        #endregion
    }
}
