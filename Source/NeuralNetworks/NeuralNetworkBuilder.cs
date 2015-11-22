using Source.NeuralNetworks.Layers;
using Source.NeuralNetworks.Layers.Connections;
using Source.NeuralNetworks.Layers.Perceptrons;


namespace Source.NeuralNetworks
{
	public class NeuralNetworkBuilder
	{
		private readonly ConnectionProperties _connectionProperties;
		private readonly PerceptronProperties _perceptronProperties;
		private readonly LayerDictionary _layerDictionary;
		private readonly LayerProperties _layerProperties;

		private int _index;
		private int _leftPerceptrons;
		private int _rightPerceptrons;

		public NeuralNetworkBuilder(ConnectionProperties connectionProperties, PerceptronProperties perceptronProperties)
		{
			_layerDictionary = new LayerDictionary();
			_perceptronProperties = perceptronProperties;
			_connectionProperties = connectionProperties;

			_layerProperties = new LayerProperties
			{
				ConnectionProperties = connectionProperties,
				PerceptronProperties = perceptronProperties
			};
		}

		public NeuralNetwork Build()
		{
			_perceptronProperties.IsEntryPerceptronList = false;
			_perceptronProperties.PreviousLayer = _layerDictionary[_index];
			_layerProperties.PerceptronProperties.IsEntryPerceptronList = false;
			_layerProperties.PerceptronProperties.PreviousLayer = _layerDictionary[_index];
			_layerDictionary.Add(_index + 1, new Layer(_rightPerceptrons, 0, _connectionProperties, _perceptronProperties));
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
			_layerProperties.LeftPerceptrons = leftPerceptrons;
			return this;
		}

		public NeuralNetworkBuilder To(int rightPerceptrons)
		{
			_rightPerceptrons = rightPerceptrons;
			_layerProperties.RightPerceptrons = rightPerceptrons;

			if (_layerDictionary.HasLayer(_index - 1))
			{
				_perceptronProperties.IsEntryPerceptronList = false;
				_perceptronProperties.PreviousLayer = _layerDictionary[_index - 1];
				_layerProperties.PerceptronProperties.IsEntryPerceptronList = false;
				_layerProperties.PerceptronProperties.PreviousLayer = _layerDictionary[_index - 1];
				_layerDictionary.Add(_index, new Layer(_layerProperties));
			}
			else
			{
				_perceptronProperties.IsEntryPerceptronList = true;
				_layerProperties.PerceptronProperties.IsEntryPerceptronList = true;
				_layerDictionary.Add(_index, new Layer(_layerProperties));
			}

			return this;
		}
	}
}