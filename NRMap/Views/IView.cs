using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRMap.Controllers;

namespace NRMap.Views
{
    public interface IView
    {
        void AddListener(IController controller);


       // public void AddLayer(Object layer);
    }

    
}
