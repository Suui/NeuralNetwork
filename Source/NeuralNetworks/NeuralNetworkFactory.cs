using Source.NeuralNetworks.Layers.Connections;
using Source.NeuralNetworks.Layers.Perceptrons;
using Source.NumberGenerators;


namespace Source.NeuralNetworks
{
	public class NeuralNetworkFactory
	{
		public static NeuralNetwork NeuralNetworkForPracticeFour()
		{
			var weightGenerator = new DelimitedRandom(-10000, 10000);
			var thresholdGenerator = new DelimitedRandom(-10000, 10000);

			return new NeuralNetworkBuilder(new ConnectionProperties(weightGenerator), new PerceptronProperties(thresholdGenerator))
						.WithLayer(1).From(784).To(392)
						.WithLayer(2).From(392).To(196)
						.WithLayer(1).From(196).To(1)
						.Build();
        }
	}
}