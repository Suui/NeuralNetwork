using System.Collections.Generic;
using Source.NeuralNetworks.Layers.Perceptrons;


namespace Source.NeuralNetworks.Layers
{
	public class LayerDictionary
	{
		private Dictionary<int, Layer> Layers { get; }
		public int Count => Layers.Count;

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
			for (var i = 1; i <= Layers[1].CountPerceptrons; i++)
			{
				Layers[1].Perceptron(i).EntryValue = entryValues[i];
			}
		}
	}
}