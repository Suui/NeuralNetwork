using System.Collections.Generic;


namespace Source.Layers
{
	public class LayerList
	{
		public List<Layer> Layers { get; set; }
		public Dictionary<int, Layer>  LayerDictionary { get; set; }

		public LayerList()
		{
			Layers = new List<Layer>();
			LayerDictionary = new Dictionary<int, Layer>();
		}

		public bool HasLayer(int index)
		{
			return LayerDictionary.ContainsKey(index);
		}

		public Layer this[int index] => LayerDictionary[index];
	}
}