using Source.NeuralNetworks.Layers;


namespace Source.NeuralNetworks
{
	public class NeuralNetworkBuilder
	{
		private readonly LayerDictionary _layerDictionary;
		private int _index;
		private int _leftPerceptrons;

		public NeuralNetworkBuilder()
		{
			_layerDictionary = new LayerDictionary();
		}

		public NeuralNetworkBuilder Build()
		{
			return this;
		}

		public NeuralNetworkBuilder WithLayer(int index)
		{
			_index = index;
			return this;
		}

		public NeuralNetworkBuilder From(int leftPerceptrons)
		{
			_leftPerceptrons = leftPerceptrons;
			return this;
		}

		public NeuralNetworkBuilder To(int rightPerceptrons)
		{
			_layerDictionary.Add(_index,
				_layerDictionary.HasLayer(_index - 1) ? new Layer(_leftPerceptrons, rightPerceptrons, _layerDictionary[_index - 1])
					: new Layer(_leftPerceptrons, rightPerceptrons));
			return this;
		}

		public NeuralNetwork Get()
		{
			return new NeuralNetwork(_layerDictionary);
		}
	}
}