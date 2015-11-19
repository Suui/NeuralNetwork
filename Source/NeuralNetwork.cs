using System.Collections.Generic;
using Source.Layers;

namespace Source
{
	public class NeuralNetwork
	{
		private LayerDictionary LayerDictionary { get; }
		public List<double> ExitValues { get; set; }

		public NeuralNetwork(LayerDictionary layers)
		{
			LayerDictionary = layers;
			ExitValues = new List<double>();
		}

		public void Execute()
		{
			ExitValues = LayerDictionary.GetLastLayerExitValues();
		}
	}
}