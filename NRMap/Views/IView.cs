using NRMap.Controllers;
using SharpMap.Layers;

namespace NRMap.Views
{
    public interface IView
    {
        void AddListener(IController controller);

        string TextCoord { set; }

        void AddLayer(ILayer layer);
        ILayer GetLayerByName(string layerName);
        void RemoveLayer(ILayer layer);
    }
}
