using Source.NeuralNetworks.Layers;


namespace Source.NeuralNetworks
{
	public class NeuralNetworkBuilder
	{
		private readonly LayerDictionary _layerDictionary;
		private int _index;
		private int _leftPerceptrons;
		private int _rightPerceptrons;

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
			_rightPerceptrons = rightPerceptrons;

			_layerDictionary.Add(_index,
				_layerDictionary.HasLayer(_index - 1) ? new Layer(_leftPerceptrons, _rightPerceptrons, _layerDictionary[_index - 1])
													  : new Layer(_leftPerceptrons, _rightPerceptrons));
			return this;
		}

		public NeuralNetwork Get()
		{
			_layerDictionary.Add(_index + 1, new Layer(_rightPerceptrons, 0, _layerDictionary[_index - 1]));
			return new NeuralNetwork(_layerDictionary);
		}
	}
}