using Source.AcceptanceMatchers;
using Source.NeuralNetworks.Layers;
using Source.NeuralNetworks.Layers.Connections;
using Source.NeuralNetworks.Layers.Perceptrons;


namespace Source.NeuralNetworks
{
	public class NeuralNetworkBuilder
	{
		private readonly LayerDictionary _layerDictionary;
		private readonly LayerProperties _layerProperties;
		private readonly AcceptanceMatcher _acceptanceMatcher;
		private int _index;

		public NeuralNetworkBuilder(ConnectionProperties connectionProperties, PerceptronProperties perceptronProperties)
		{
			_layerDictionary = new LayerDictionary();

			_layerProperties = new LayerProperties
			{
				ConnectionProperties = connectionProperties,
				PerceptronProperties = perceptronProperties
			};
		}

		public NeuralNetworkBuilder(ConnectionProperties connectionProperties, PerceptronProperties perceptronProperties, AcceptanceMatcher acceptanceMatcher)
		{
			_layerDictionary = new LayerDictionary();
			_acceptanceMatcher = acceptanceMatcher;

			_layerProperties = new LayerProperties
			{
				ConnectionProperties = connectionProperties,
				PerceptronProperties = perceptronProperties
			};
		}

		public NeuralNetwork Build()
		{
			_layerProperties.PerceptronProperties.IsEntryPerceptronList = false;
			_layerProperties.PerceptronProperties.PreviousLayer = _layerDictionary[_index];
			_layerProperties.LeftPerceptrons = _layerProperties.RightPerceptrons;
			_layerProperties.RightPerceptrons = 0;
			_layerDictionary.Add(_index + 1, new Layer(_layerProperties));
			return new NeuralNetwork(_layerDictionary, _acceptanceMatcher);
		}

		public NeuralNetworkBuilder WithLayer(int index)
		{
			_index = index;
			return this;
		}

		public NeuralNetworkBuilder From(int leftPerceptrons)
		{
			_layerProperties.LeftPerceptrons = leftPerceptrons;
			return this;
		}

		public NeuralNetworkBuilder To(int rightPerceptrons)
		{
			_layerProperties.RightPerceptrons = rightPerceptrons;

			if (_layerDictionary.HasLayer(_index - 1))
			{
				_layerProperties.PerceptronProperties.IsEntryPerceptronList = false;
				_layerProperties.PerceptronProperties.PreviousLayer = _layerDictionary[_index - 1];
				_layerDictionary.Add(_index, new Layer(_layerProperties));
			}
			else
			{
				_layerProperties.PerceptronProperties.IsEntryPerceptronList = true;
				_layerDictionary.Add(_index, new Layer(_layerProperties));
			}

			return this;
		}
	}
}