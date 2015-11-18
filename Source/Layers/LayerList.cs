using System.Collections.Generic;


namespace Source.Layers
{
	public class LayerList
	{
		public Dictionary<int, Layer>  LayerDictionary { get; set; }

		public LayerList()
		{
			LayerDictionary = new Dictionary<int, Layer>();
		}

		public bool HasLayer(int index)
		{
			return LayerDictionary.ContainsKey(index);
		}

		public Layer this[int index] => LayerDictionary[index];
	}
}