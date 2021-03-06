﻿using System;
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
            // https://github.com/SharpMap/SharpMapV2/blob/master/SharpMap.Data.Providers/PostGisProvider/PostGisProvider.cs
            // http://www.sharpgis.net/post/2006/04/06/Adding-SharpMap-geometry-to-a-PostGIS-database
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MapForm mapForm = new MapForm();

            Controllers.IController controller = new Controllers.Controller(mapForm);

            Application.Run(mapForm);
            
        }
    }
}
