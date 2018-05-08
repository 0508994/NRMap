using Npgsql;
using System.Data;
using SharpMap.Data;
using System.Collections.Generic;
using GeoAPI.Geometries;

namespace NRMap.Utilities
{
    public class PostGISCustom 
    {
        private const string _tempGeom = "sharpmap_tempgeometry";
        private string _connString;
        private string _geomColumn;
        private string _querySQL;

        public string ConnString { get => _connString; set => _connString = value; }
        public string GeomColumn { get => _geomColumn; set => _geomColumn = value; }
        public string QuerySQL { get => _querySQL; set => _querySQL = value; }

        public PostGISCustom() { }

        public PostGISCustom(string connectionString, string geometryColumnName)
        {
            _connString = connectionString;
            _geomColumn = geometryColumnName;
        }
        public void ExecuteCustomQuery(FeatureDataSet fds)
        {
            NpgsqlConnection conn = new NpgsqlConnection(_connString);

            GeoAPI.Geometries.IGeometryFactory gFactory =
                new NetTopologySuite.Geometries.GeometryFactory(new NetTopologySuite.Geometries.PrecisionModel(), 4326);

            DataSet ds1 = new DataSet();
            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(_querySQL, conn))
            {
                conn.Open();
                adapter.Fill(ds1);
                conn.Close();

                if (ds1.Tables.Count > 0)
                {
                    FeatureDataTable fdt = new FeatureDataTable(ds1.Tables[0]);
                    foreach (DataColumn col in ds1.Tables[0].Columns)
                        if (col.ColumnName != _geomColumn && col.ColumnName != "sharpmap_tempgeometry")
                            fdt.Columns.Add(col.ColumnName, col.DataType, col.Expression);
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        FeatureDataRow fdr = fdt.NewRow();
                        foreach (DataColumn col in ds1.Tables[0].Columns)
                            if (col.ColumnName != _geomColumn && col.ColumnName != "sharpmap_tempgeometry")
                                fdr[col.ColumnName] = dr[col];
                        fdr.Geometry = SharpMap.Converters.WellKnownBinary.GeometryFromWKB.Parse((byte[]) dr["sharpmap_tempgeometry"], gFactory);
                        fdt.AddRow(fdr);
                    }
                    fds.Tables.Add(fdt);
                }
            }
        }

        public IList<IGeometry> ExecuteCustomQuery(DataSet ds)
        {
            NpgsqlConnection conn = new NpgsqlConnection(_connString);

            GeoAPI.Geometries.IGeometryFactory gFactory =
                new NetTopologySuite.Geometries.GeometryFactory(new NetTopologySuite.Geometries.PrecisionModel(), 4326);

            IList<IGeometry> geometries = new List<IGeometry>();

            DataSet ds1 = new DataSet();
            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(_querySQL, conn))
            {
                conn.Open();
                adapter.Fill(ds1);
                conn.Close();

                if (ds1.Tables.Count > 0)
                {
                    FeatureDataTable fdt = new FeatureDataTable(ds1.Tables[0]);
                    foreach (DataColumn col in ds1.Tables[0].Columns)
                        if (col.ColumnName != _geomColumn && col.ColumnName != "sharpmap_tempgeometry")
                            fdt.Columns.Add(col.ColumnName, col.DataType, col.Expression);
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        FeatureDataRow fdr = fdt.NewRow();
                        foreach (DataColumn col in ds1.Tables[0].Columns)
                            if (col.ColumnName != _geomColumn && col.ColumnName != "sharpmap_tempgeometry")
                                fdr[col.ColumnName] = dr[col];
                        geometries.Add(SharpMap.Converters.WellKnownBinary.GeometryFromWKB.Parse((byte[])dr["sharpmap_tempgeometry"], gFactory));
                        fdt.AddRow(fdr);
                    }
                    ds.Tables.Add(fdt);
                    return geometries;
                }
                return null;
            }
        }




        public void BuildWithinQuery(string sourceTable, string targetTable, string definitionQuery)
        {
            _querySQL = string.Format(
                "SELECT sl.*, ST_AsBinary(sl.{0}) AS {1} " +
                "FROM {2} AS sl, {3} as tl " +
                "WHERE {4} AND ST_Within(sl.{0}, tl.{0})",
                _geomColumn, _tempGeom, sourceTable, targetTable,  definitionQuery);
        }

        public void BuildDWithinQuery(string sourceTable, string targetTable, string definitionQuery, double distance)
        {
            _querySQL = string.Format(
                "SELECT sl.*, ST_AsBinary(sl.{0}) AS {1} " +
                "FROM {2} AS sl, {3} as tl " +
                "WHERE {4} AND ST_DWithin(sl.{0}, tl.{0}, {5})",
                _geomColumn, _tempGeom, sourceTable, targetTable, definitionQuery, distance);
        }

        public void BuildCrossesQuery(string sourceTable, string targetTable, string definitionQuery)
        {
            _querySQL = string.Format(
                "SELECT sl.*, ST_AsBinary(sl.{0}) AS {1} " +
                "FROM {2} AS sl, {3} as tl " +
                "WHERE {4} AND ST_Crosses(sl.{0}, tl.{0})",
                _geomColumn, _tempGeom, sourceTable, targetTable, definitionQuery);
        }

        public void BuildOverlapsQuery(string sourceTable, string targetTable, string definitionQuery)
        {
            _querySQL = string.Format(
                "SELECT sl.*, ST_AsBinary(sl.{0}) AS {1} " +
                "FROM {2} AS sl, {3} as tl " +
                "WHERE {4} AND ST_Within(sl.{0}, tl.{0})",
                _geomColumn, _tempGeom, sourceTable, targetTable, definitionQuery);
        }

        public void BuildTouchesQuery(string sourceTable, string targetTable, string definitionQuery)
        {
            _querySQL = string.Format(
                "SELECT sl.*, ST_AsBinary(sl.{0}) AS {1} " +
                "FROM {2} AS sl, {3} as tl " +
                "WHERE {4} AND ST_Touches(sl.{0}, tl.{0})",
                _geomColumn, _tempGeom, sourceTable, targetTable, definitionQuery);
        }

        public void BuildIntersectsQuery(string sourceTable, string targetTable, string definitionQuery)
        {
            _querySQL = string.Format(
                "SELECT sl.*, ST_AsBinary(sl.{0}) AS {1} " +
                "FROM {2} AS sl, {3} as tl " +
                "WHERE {4} AND ST_Intersects(sl.{0}, tl.{0})",
                _geomColumn, _tempGeom, sourceTable, targetTable, definitionQuery);
        }

        public void BuildRelationQuery(string sourceTable, string targetTable, string definitionQuery,
            int opCode, double distance)
        { 
            switch (opCode)
            {
                case (Constants.within):
                    BuildWithinQuery(sourceTable, targetTable, definitionQuery);
                    break;
                case (Constants.dWithin):
                    BuildDWithinQuery(sourceTable, targetTable, definitionQuery, distance);
                    break;
                case (Constants.intersects):
                    BuildIntersectsQuery(sourceTable, targetTable, definitionQuery);
                    break;
                case (Constants.touches):
                    BuildTouchesQuery(sourceTable, targetTable, definitionQuery);
                    break;
                case (Constants.overlaps):
                    BuildOverlapsQuery(sourceTable, targetTable, definitionQuery);
                    break;
                case (Constants.crosses):
                    BuildCrossesQuery(sourceTable, targetTable, definitionQuery);
                    break;
                default:
                    break;

            }
        }
    }
}
