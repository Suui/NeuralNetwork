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
	}
}