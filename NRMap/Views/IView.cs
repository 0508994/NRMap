using NRMap.Controllers;
using SharpMap.Layers;
using System.Data;

namespace NRMap.Views
{
    public interface IView
    {
        void AddListener(IController controller);

        string TextCoord { set; }
        DataTable DataGridView { set; }

        void AddLayer(ILayer layer);
        ILayer GetLayerByName(string layerName);
        void RemoveLayer(ILayer layer);
    }
}
