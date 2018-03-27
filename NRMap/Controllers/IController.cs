using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRMap.Controllers
{
    public interface IController
    {
        bool BShowUTM { set; }



        void OnMapMouseMoved(GeoAPI.Geometries.Coordinate point);
    }
}
