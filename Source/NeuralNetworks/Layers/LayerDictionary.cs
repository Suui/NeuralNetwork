using System.Collections.Generic;
using System.Linq;
using Source.NeuralNetworks.Layers.Perceptrons;


namespace Source.NeuralNetworks.Layers
{
	public class LayerDictionary
	{
		private Dictionary<int, Layer> Layers { get; }
		private Layer _lastLayer;

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
			_lastLayer = layer;
		}

		public ValueList<double> GetLastLayerExitValues()
		{
			var exitValues = new ValueList<double>();

			foreach (Perceptron perceptron in _lastLayer.Perceptrons)
				exitValues.Add(perceptron.ExitValue());

			return exitValues;
		}

		public Layer this[int index] => Layers[index];

		public void SetEntryPerceptrons(ValueList<double> entryValues)
		{
			var index = 1;
			foreach (Perceptron perceptron in Layers[1].Perceptrons)
			{
				perceptron.EntryValue = entryValues[index];
				index += 1;
			}
		}
	}
}