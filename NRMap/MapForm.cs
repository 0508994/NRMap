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
        private int _routingSource = -1;
        private int _routingTarget = -1;

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
            if (_mapBox.Map.Layers.Count == 2 || _mapBox.Map.Layers.Count == 1)
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
                MessageBox.Show("Couldn't remove layer.");
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
                MessageBox.Show("Couldn't remove layer.");
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
                MessageBox.Show("Couldn't remove layer.");
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
                MessageBox.Show("Couldn't remove layer.");
            }
        }

        private void BtnAdvanceQ_Click(object sender, EventArgs e)
        {
            SpatialQueriesForm sqf = new SpatialQueriesForm();
            try
            {
                sqf.ShowDialog();
                if (sqf.DialogResult == DialogResult.OK)
                {
                    double dWithin = 0;
                    if (sqf.OpCode == Constants.dWithin && !Double.TryParse(sqf.DWithinDistance, out dWithin))
                    {
                        MessageBox.Show("Only numerical values for distance allowed.");
                        sqf.Dispose();
                        return;
                    }
                    _controller.OnAdvanceQuery(sqf.SourceLayer, sqf.TargetLayer,
                        sqf.DefinitionQuery, sqf.OpCode, dWithin);
                }
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sqf.Dispose();
            }
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)
                    _dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                string columnName = _dataGridView.Columns[e.ColumnIndex].Name;

                if (columnName == "source")
                {
                    _routingSource = (int)cell.Value;
                    MessageBox.Show("Routing source set to " + _routingSource + ".");
                }
                else if (columnName == "target")
                {
                    _routingTarget = (int)cell.Value;
                    MessageBox.Show("Routing target set to " + _routingTarget + ".");
                }
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
            }

        }

        private void BtnRouting_Click(object sender, EventArgs e)
        {
            try
            {
                if (_routingSource != -1 && _routingTarget != -1)
                    _controller.OnFindRoute(_routingSource, _routingTarget);
                else
                    MessageBox.Show("Please set routing source and routing target first.");
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
#if DEBUG
                MessageBox.Show(exception.ToString());
#endif
            }
        }
        #endregion
    }
}
