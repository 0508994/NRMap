using System;
using System.Windows.Forms;
using NRMap.Controllers;
using NRMap.Views;
using SharpMap.Layers;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;

namespace NRMap
{
    public partial class MapForm : Form, IView
    {
        private IController _controller;

        public MapForm()
        {
            InitializeComponent();
            //AddTiledLayerAsBackground();
        }

        public void AddListener(IController controller)
        {
            _controller = controller;
            _controller.BShowUTM = cbShowUTM.Checked;
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
            mapBox.Map.BackgroundLayer.Add(new SharpMap.Layers.TileAsyncLayer(
                new BruTile.Web.OsmTileSource(), "OSM"));

            mapBox.Map.ZoomToExtents();
            mapBox.Refresh();
            mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.Pan;
        }

        public void AddLayer(ILayer layer)
        {
            mapBox.Map.Layers.Add(layer);

            mapBox.Map.ZoomToExtents();
            mapBox.Refresh();
            mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.Pan;
        }

        #region Events
        private void mapBox_MouseMove(GeoAPI.Geometries.Coordinate worldPos, MouseEventArgs imagePos)
        {
            _controller.OnMapMouseMoved(worldPos);
        }

        private void cbShowUTM_CheckedChanged(object sender, EventArgs e)
        {
            _controller.BShowUTM = cbShowUTM.Checked;
        }
        #endregion

        // testing db connection and styles
        // REMOVE LATER
        private void button1_Click(object sender, EventArgs e)
        {
            _controller.OnAddRoadsLayer();
        }
    }
}
