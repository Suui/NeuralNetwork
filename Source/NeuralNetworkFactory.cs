using Source.Layers;

namespace Source
{
	public class NeuralNetworkFactory
	{
		public static NeuralNetwork BuildNeuralNetworkForPractice()
		{
			LayerDictionary layers = new LayerDictionary();

			return new NeuralNetwork(layers);
		}
	}
}