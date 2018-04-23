﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRMap.Controllers;
using SharpMap.Layers;

namespace NRMap.Views
{
    public interface IView
    {
        void AddListener(IController controller);

        string TextCoord { set; }

        void AddLayer(ILayer layer);
    }
}
