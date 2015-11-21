using Source.NeuralNetworks.Layers;
using Source.NeuralNetworks.Layers.Perceptrons;


namespace Source.NeuralNetworks
{
	public class NeuralNetworkBuilder
	{
		private readonly LayerDictionary _layerDictionary;

		private PerceptronProperties _perceptronProperties;
		private int _index;
		private int _leftPerceptrons;
		private int _rightPerceptrons;


		public NeuralNetworkBuilder()
		{
			_layerDictionary = new LayerDictionary();
		}

		public NeuralNetworkBuilder(PerceptronProperties perceptronProperties)
		{
			_layerDictionary = new LayerDictionary();
			_perceptronProperties = perceptronProperties;
		}

		public NeuralNetwork Build()
		{
			_perceptronProperties.PreviousLayer = _layerDictionary[_index];
			_layerDictionary.Add(_index + 1, new Layer(_rightPerceptrons, 0, _perceptronProperties));
			return new NeuralNetwork(_layerDictionary);
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

			if (_layerDictionary.HasLayer(_index - 1))
			{
				_perceptronProperties.PreviousLayer = _layerDictionary[_index - 1];
				_layerDictionary.Add(_index, new Layer(_leftPerceptrons, _rightPerceptrons, _perceptronProperties));
			}
			else
			{
				_perceptronProperties.IsEntryPerceptronList = true;
				_layerDictionary.Add(_index, new Layer(_leftPerceptrons, _rightPerceptrons, _perceptronProperties));
			}

			return this;
		}
	}
}