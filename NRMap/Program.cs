using System;
using System.Windows.Forms;

namespace NRMap
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // https://gis.stackexchange.com/questions/48949/epsg-3857-or-4326-for-googlemaps-openstreetmap-and-leaflet
            // https://stackoverflow.com/questions/9595681/creating-new-layers-in-sharpmap
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MapForm mapForm = new MapForm();

            NRMap.Controllers.IController controller = new NRMap.Controllers.Controller(mapForm);

            Application.Run(mapForm);
            
        }
    }
}
