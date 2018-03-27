using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NRMap.Controllers;
using NRMap.Views;

namespace NRMap
{
    public partial class MapForm : Form, IView
    {
        private IController _controller;

        public MapForm()
        {
            InitializeComponent();
            AddTiledLayerAsBackground();
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

        public void AddTiledLayerAsBackground()
        {
            mapBox.Map.BackgroundLayer.Add(new SharpMap.Layers.TileAsyncLayer(
                new BruTile.Web.OsmTileSource(), "OSM"));

            mapBox.Map.ZoomToExtents();
            mapBox.Refresh();
            mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.Pan;
        }

        private void mapBox_MouseMove(GeoAPI.Geometries.Coordinate worldPos, MouseEventArgs imagePos)
        {
            _controller.OnMapMouseMoved(worldPos);
        }

        private void cbShowUTM_CheckedChanged(object sender, EventArgs e)
        {
            _controller.BShowUTM = cbShowUTM.Checked;
        }
    }
}
