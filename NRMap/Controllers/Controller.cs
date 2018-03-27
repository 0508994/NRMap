using NRMap.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRMap.Controllers
{
    public class Controller : IController
    {
        private IView _view;

        public Controller(IView view)
        {
            _view = view;
            _view.AddListener(this);
        }
    }
}
