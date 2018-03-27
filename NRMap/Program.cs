using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MapForm mapForm = new MapForm();

            NRMap.Controllers.IController controller = new NRMap.Controllers.Controller(mapForm);

            Application.Run(mapForm);
            
        }
    }
}
