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


		private int Index;
		private int LeftPerceptrons;

		public LayerList WithLayer(int index)
		{
			Index = index;
			return this;
		}

		public LayerList From(int leftPerceptrons)
		{
			LeftPerceptrons = leftPerceptrons;
			return this;
		}

		public LayerList To(int rightPerceptrons)
		{
			Layers.Add(new Layer(Index, LeftPerceptrons, rightPerceptrons));
			return this;
		}
	}
}