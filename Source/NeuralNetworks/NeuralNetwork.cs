using System.Collections.Generic;
using Source.NeuralNetworks.Layers;


namespace Source.NeuralNetworks
{
	public class NeuralNetwork
	{
		private LayerDictionary LayerDictionary { get; }
		public List<double> EntryValues { get; set; }
		public List<double> ExitValues { get; set; }
		public List<double> ExpectedExitValues { get; set; }

		public NeuralNetwork(LayerDictionary layers)
		{
			LayerDictionary = layers;
			EntryValues = new List<double>();
			ExitValues = new List<double>();
		}

		public void Execute()
		{
			if (EntryValues.Count != 0)
				LayerDictionary.SetEntryPerceptrons(EntryValues);

			ExitValues = LayerDictionary.GetLastLayerExitValues();
		}

		public double GetErrorForExit(int i)
		{
			var index = i-1;
			return -(ExpectedExitValues[index] - ExitValues[index]);
		}

		public void ExecuteBackPropagation()
		{
			var w = LayerDictionary[1].Connection(1, 1).Weight;
			w = w -0.1 * EntryValues[0] * ExitValues[0] * (1 - ExitValues[0]) * GetErrorForExit(1);
		}
	}
}