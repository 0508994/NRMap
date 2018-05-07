namespace NRMap.Views
{
    public interface IView
    {
        void AddListener(Controllers.IController controller);

        string TextCoord { set; }
        System.Data.DataTable DataGridView { set; }

        void AddLayer(SharpMap.Layers.ILayer layer);
        SharpMap.Layers.ILayer GetLayerByName(string layerName);
        void RemoveLayer(SharpMap.Layers.ILayer layer);
    }
}
