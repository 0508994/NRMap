using System;
using System.Windows.Forms;
using NRMap.Controllers;
using NRMap.Views;
using SharpMap.Layers;
using System.Data;
using GeoAPI.Geometries;
using System.Collections.Generic;
using NRMap.Utilities;

namespace NRMap
{
    public partial class MapForm : Form, IView
    {
        private IController _controller;
        private Coordinate _lastClick = null;

        public MapForm()
        {
            InitializeComponent();
            //AddTiledLayerAsBackground();
            _lbLayerDescription.Text = Constants.roadsLayerDescr;
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

        // Uselles
        public void AddTiledLayerAsBackground()
        {
            _mapBox.Map.BackgroundLayer.Add(new SharpMap.Layers.TileAsyncLayer(
                new BruTile.Web.OsmTileSource(), "OSM"));

            _mapBox.Map.ZoomToExtents();
            _mapBox.Refresh();
            _mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.Pan;
        }

        // Add layer to the map
        public void AddLayer(ILayer layer)
        {
            _mapBox.Map.Layers.Add(layer);

            // Zoom for the first one only
            if (_mapBox.Map.Layers.Count == 2)
                _mapBox.Map.ZoomToExtents();
            _mapBox.Refresh();
        }

        // Get layer by name (set in constructor - Controller)
        public ILayer GetLayerByName(string layerName)
        {
            return _mapBox.Map.GetLayerByName(layerName);
        }

        // Remove the given layer from the map
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
            {
                _controller.ActiveLayer = Constants.roadsTable;
                _lbLayerDescription.Text = Constants.roadsLayerDescr;
            }
        }

        private void RbNR_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbNR.Checked)
            {
                _controller.ActiveLayer = Constants.nrTable;
                _lbLayerDescription.Text = Constants.nrLayerDescr;
            }
        }

        private void RbWaters_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbWaters.Checked)
            {
                _controller.ActiveLayer = Constants.watersTable;
                _lbLayerDescription.Text = Constants.watersLayerDescr;
            }
        }

        private void MapBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                _lastClick = _mapBox.Map.ImageToWorld(new System.Drawing.PointF(e.X, e.Y));
                _tbBBoxMp.Text = _lastClick.X + "  " + _lastClick.Y;

                if (!_cbActivatePan.Checked)
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
                //double[] bottomleft = { _lastClick.X, _lastClick.Y - bboxH };
                //double[] topRight = { _lastClick.X + bboxW, _lastClick.Y };
                double[] bottomRight = { _lastClick.X + bboxW, _lastClick.Y - bboxH};

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

        private void BtnPickQRColor_Click(object sender, EventArgs e)
        {
            if (_colorPicker.ShowDialog() == DialogResult.OK)
            {
                _btnPickQRColor.BackColor = _colorPicker.Color;
            }
        }

        private void BtnQueryLayer_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.OnQueryLayer(_rtbQuery.Text, _colorPicker.Color);
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                //MessageBox.Show(exception.ToString());
            }
        }

        private void BtnRmQR_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.OnRemoveLayer(Constants.queryLayerName);
                _controller.OnRemoveLayer(Constants.queryLabelName);
                _dataGridView.Columns.Clear();
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                MessageBox.Show("Couldn't remove the layer.");
            }
        }

        #endregion

        private void _btnAdvanceQ_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.OnAdvanceQuery(null, null, null, null, null);
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                MessageBox.Show(exception.ToString());
            }
        }
    }
}
