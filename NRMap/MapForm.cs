using System;
using System.Windows.Forms;
using NRMap.Controllers;
using NRMap.Views;
using SharpMap.Layers;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using System.Data;
using GeoAPI.Geometries;
using Npgsql;
using System.Collections.Generic;

namespace NRMap
{
    public partial class MapForm : Form, IView
    {
        private IController _controller;
        private Coordinate _lastClick = null;

        public MapForm()
        {
            InitializeComponent();
            AddTiledLayerAsBackground();

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
                _lbTextCoord.Text = value;
            }
        }

        public DataTable DataGridView
        {
            // never used
            get
            {
                return (DataTable)_dataGridView.DataSource;
            }
            set
            {
                _dataGridView.Columns.Clear();
                _dataGridView.DataSource = value;
            }

        }

        public void AddTiledLayerAsBackground()
        {
            //_mapBox.Map.BackgroundLayer.Add(new SharpMap.Layers.TileAsyncLayer(
            //    new BruTile.Web.OsmTileSource(), "OSM"));

            //_mapBox.Map.ZoomToExtents();
            //_mapBox.Refresh();
            //_mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.Pan;
        }

        public void AddLayer(ILayer layer)
        {
            _mapBox.Map.Layers.Add(layer);

            _mapBox.Map.ZoomToExtents();
            _mapBox.Refresh();
            //_mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.Pan;
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
        private void MapBox_MouseMove(Coordinate worldPos, MouseEventArgs imagePos)
        {
            _controller.OnMapMouseMoved(worldPos);
        }

        private void CbShowUTM_CheckedChanged(object sender, EventArgs e)
        {
            _controller.BShowUTM = _cbShowUTM.Checked;
        }

        private void CbActivatePan_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbActivatePan.Checked)
                _mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.Pan;
            else
                _mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.None;
        }

        private void RbRoads_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbRoads.Checked)
                _controller.ActiveLayer = Constants.roadsTable;
        }

        private void RbNR_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbNR.Checked)
                _controller.ActiveLayer = Constants.nrTable;
        }

        private void RbWaters_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbWaters.Checked)
                _controller.ActiveLayer = Constants.watersTable;
        }

        private void MapBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                _lastClick = _mapBox.Map.ImageToWorld(new System.Drawing.PointF(e.X, e.Y));
                //_mapBox.Map.Center.X = p.X;
                //_mapBox.Map.Center.Y = p.Y;
                //_mapBox.Refresh();
                _tbBBoxMp.Text = _lastClick.X + "  " + _lastClick.Y;
                _controller.OnMapMouseClick(_lastClick);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void BtnAddRoads_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.OnAddRoadsLayer();
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
                MessageBox.Show("Couldn't connect to the database.");
            }
            
        }

        private void BtnAddNR_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.OnAddNRLayer();
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                MessageBox.Show(exception.ToString());
            }
        }

        private void BtnAddWaters_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.OnAddWatersLayer();
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                MessageBox.Show(exception.ToString());
            }
        }

        private void BtnRmRoads_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.OnRemoveLayer(Constants.roadsLayerName);
                _controller.OnRemoveLayer(Constants.roadsLabelName);
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                MessageBox.Show("Couldn't remove the layer.");
            }
        }

        private void BtnRmNR_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.OnRemoveLayer(Constants.nrLayerName);
                _controller.OnRemoveLayer(Constants.nrLabelName);
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                MessageBox.Show("Couldn't remove the layer.");
            }
        }

        private void BtnRmWaters_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.OnRemoveLayer(Constants.watersLayerName);
                _controller.OnRemoveLayer(Constants.watersLabelName);
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                MessageBox.Show("Couldn't remove the layer.");
            }
        }

        private void BtnGetBBox_Click(object sender, EventArgs e)
        {
            try
            {
                double bboxH = Double.Parse(_tbBBoxH.Text);
                double bboxW = Double.Parse(_tbBBoxW.Text);

                double[] topLeft = { _lastClick.X, _lastClick.Y };
                //double[] bottomleft = { _lastClick.X, _lastClick.Y + bboxH };
                //double[] topRight = { _lastClick.X + bboxW, _lastClick.Y };
                double[] bottomRight = { _lastClick.X + bboxW, _lastClick.Y + bboxH};

                IList<double[]> coordinates = new List<double[]>()
                {
                    { topLeft },
                    //{ bottomleft },
                    //{ topRight },
                    { bottomRight }
                };
                _controller.OnReturnBBoxFeatures(coordinates);

            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
                MessageBox.Show("Invalid input!");
            }
            
        }
        #endregion

        // https://github.com/SharpMap/SharpMapV2/blob/master/SharpMap.Data.Providers/PostGisProvider/PostGisProvider.cs
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

        // djubre vraca sve iz podatke iz sloja
        private void _mapBox_MapQueried(SharpMap.Data.FeatureDataTable data)
        {
            //_dataGridView.DataSource = data;
            //MessageBox.Show(data.Rows.Count.ToString());
        }


    }
}
