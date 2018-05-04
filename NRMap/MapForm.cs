using System;
using System.Windows.Forms;
using NRMap.Controllers;
using NRMap.Views;
using SharpMap.Layers;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using System.Data;
using Npgsql;

namespace NRMap
{
    public partial class MapForm : Form, IView
    {
        private IController _controller;

        public MapForm()
        {
            InitializeComponent();
            //AddTiledLayerAsBackground();

            DataTable dt = new DataTable();
            dt.Columns.Add("c1");
            dt.Columns.Add("c2");
            dt.Columns.Add("c3");
            dt.Columns.Add("c4");
            dt.Columns.Add("c5");

            for (int i = 0; i < 100; i++)
                dt.Rows.Add(new object[] { "mitar", "djuro", "muro", "perica", "erica" });

            _dataGridView.DataSource = dt;
        }

        public void AddListener(IController controller)
        {
            _controller = controller;
            _controller.BShowUTM = _cbShowUTM.Checked;
        }

        public string TextCoord
        {
            set
            {
                textCoord.Text = value;
            }
        }

        // maybe add last ? ..
        public void AddTiledLayerAsBackground()
        {      
            _mapBox.Map.BackgroundLayer.Add(new SharpMap.Layers.TileAsyncLayer(
                new BruTile.Web.OsmTileSource(), "OSM"));

            _mapBox.Map.ZoomToExtents();
            _mapBox.Refresh();
            _mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.Pan;
        }

        public void AddLayer(ILayer layer)
        {
            _mapBox.Map.Layers.Add(layer);

            _mapBox.Map.ZoomToExtents();
            _mapBox.Refresh();
            _mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.Pan;
        }

        // get layer by name (set in constructor - Controller)
        public ILayer GetLayerByName(string layerName)
        {
            return _mapBox.Map.GetLayerByName(layerName);
        }

        // remove the given layer from the map
        public void RemoveLayer(ILayer layer)
        {
            _mapBox.Map.Layers.Remove(layer);
            _mapBox.Refresh();
        }

        #region Events
        private void MapBox_MouseMove(GeoAPI.Geometries.Coordinate worldPos, MouseEventArgs imagePos)
        {
            _controller.OnMapMouseMoved(worldPos);
        }

        private void CbShowUTM_CheckedChanged(object sender, EventArgs e)
        {
            _controller.BShowUTM = _cbShowUTM.Checked;
        }

        private void BtnAddRoads_Click(object sender, EventArgs e)
        {
            _controller.OnAddRoadsLayer();
        }

        private void BtnRmRoads_Click(object sender, EventArgs e)
        {
            _controller.OnRemoveLayer(Constants.roadsLayerName);
            _controller.OnRemoveLayer(Constants.roadsLabelName);
        }
        #endregion

        // https://github.com/SharpMap/SharpMapV2/blob/master/SharpMap.Data.Providers/PostGisProvider/PostGisProvider.cs
        // TODO: probaj da preradis ovo da stavlja podatke direktno u ds
        private void Button1_Click(object sender, EventArgs e)
        {
            SharpMap.Data.Providers.PostGIS postGisProv = new
                SharpMap.Data.Providers.PostGIS(Constants.connStr, Constants.roadsTable, Constants.geomName, Constants.idName)
            {
                DefinitionQuery = "fclass = \'primary\' or fclass = \'secondary\' or fclass = \'motorway_link\'"
            };

            SharpMap.Data.FeatureDataSet fds = new SharpMap.Data.FeatureDataSet();
            postGisProv.Open();
            GeoAPI.Geometries.Envelope envelope = postGisProv.GetExtents();
            postGisProv.ExecuteIntersectionQuery(envelope, fds);
            postGisProv.Close();

            //DataTable dt = new DataTable("Test");
            //foreach (DataColumn col in fds.Tables[0].Columns)
            //    if (col.ColumnName != Constants.geomName)
            //        dt.Columns.Add(col.ColumnName, col.DataType, col.Expression);

            //foreach (DataRow dr in fds.Tables[0].Rows)
            //{
            //    DataRow newRow = dt.NewRow();
            //    foreach (DataColumn col in fds.Tables[0].Columns)
            //        if (col.ColumnName != Constants.geomName)
            //            newRow[col.ColumnName] = dr[col];
            //    dt.Rows.Add(newRow);
            //}
            _dataGridView.Columns.Clear();
            _dataGridView.DataSource = fds.Tables[0];



        }


    }
}
