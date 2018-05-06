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

        // Name of the natural resources table 
        public const string nrTable = "public.\"gis.osm_natural_free_1\"";

        // Name of the landuse table
        public const string landuseTable = "public.\"gis.osm_landuse_a_free_1\"";
        #endregion

        #region Layer and Label names
        public const string roadsLayerName = "Roads";
        public const string roadsLabelName = "RoadsLabels";

        public const string nrLayerName = "NaturalResources";
        public const string nrLabelName = "NaturalResourcesLabel";

        public const string landuseLayerName = "Landuse";
        public const string landuseLabelName = "LanduseLabel";
        #endregion
    }
}
