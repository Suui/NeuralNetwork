using System.Collections.Generic;


namespace Source.Layers
{
	public class LayerDictionary
	{
		private Dictionary<int, Layer> Layers { get; set; }

		public LayerDictionary()
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