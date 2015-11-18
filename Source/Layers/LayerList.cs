using System.Collections.Generic;


namespace Source.Layers
{
	public class LayerList
	{
		private Dictionary<int, Layer> Layers { get; set; }

		public LayerList()
		{
			Layers = new Dictionary<int, Layer>();
		}

		public bool HasLayer(int index)
		{
			return Layers.ContainsKey(index);
		}

		public void Add(int index, Layer layer)
		{
			Layers.Add(index, layer);
		}

		public Layer this[int index] => Layers[index];
	}
}