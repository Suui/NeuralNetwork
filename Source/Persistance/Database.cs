using Source.NeuralNetworks;


namespace Source.Persistance
{
	public class Database
	{
		public void SaveValuesFor(NeuralNetwork neuralNetwork)
		{
			var firstLayerWeights = neuralNetwork.GetWeightsForLayer(1);
			var secondLayerWeights = neuralNetwork.GetWeightsForLayer(2);
		}
	}
}