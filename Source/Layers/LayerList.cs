using System.Collections.Generic;


namespace Source.Layers
{
	public class LayerList
	{
		public List<Layer> Layers { get; set; }

		public LayerList()
		{
			Layers = new List<Layer>();
		}

		public LayerList With(Layer layer)
		{
			Layers.Add(layer);
			return this;
		}

		public bool Haslayer(int index)
		{
			if (index - 1 < 0) return false;

			return Layers.Count >= index - 1;
		}

		public Layer this[int index] => Layers[index-1];
	}
}