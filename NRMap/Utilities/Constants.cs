namespace NRMap.Utilities
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

        // Name of the table for the roads layer [Line]
        // public const string roadsTable = "public.\"gis.osm_roads_free_1\"";
        public const string roadsTable = "roads_routing";

        // Name of the natural resources table  [Point]
        public const string nrTable = "public.\"gis.osm_natural_free_1\"";

        // Name of the waters table [Polygon]
        public const string watersTable = "public.\"gis.osm_water_a_free_1\"";
        #endregion

        #region Layer Info
        public const string roadsLayerName = "Roads";
        public const string roadsLabelName = "RoadsLabels";
        public const string roadsLayerDescr = "Columns:\nfclass(char[ ]), name(char[ ]), maxspeed(number)\noneway[B or F], bridge[T or F], tunnel[T or F]";

        public const string nrLayerName = "NaturalResources";
        public const string nrLabelName = "NaturalResourcesLabel";
        public const string nrLayerDescr = "Columns:\nfclass(char[ ]), name(char[ ])";

        public const string watersLayerName = "Waters";
        public const string watersLabelName = "WaterLabel";
        public const string watersLayerDescr = "Columns:\nfclass(char[ ]), name(char[ ])";

        public const string queryLayerName = "Query";
        public const string queryLabelName = "QueryLabel";
        #endregion

        #region Operation Codes
        public const int within = 1;
        public const int dWithin = 2;
        public const int intersects = 3;
        public const int touches = 4;
        public const int overlaps = 5;
        public const int crosses = 6;
        #endregion


    }
}
