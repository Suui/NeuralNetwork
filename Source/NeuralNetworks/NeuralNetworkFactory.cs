using Source.NeuralNetworks.Layers;


namespace Source.NeuralNetworks
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