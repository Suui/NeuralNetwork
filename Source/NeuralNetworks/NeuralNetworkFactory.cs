using Source.AcceptanceMatchers;
using Source.NeuralNetworks.Layers.Connections;
using Source.NeuralNetworks.Layers.Perceptrons;
using Source.NumberGenerators;


namespace Source.NeuralNetworks
{
	public class NeuralNetworkFactory
	{
		public static NeuralNetwork NeuralNetworkForPracticeFour()
		{
			var weightGenerator = new DelimitedRandom(-1, 1);
			var thresholdGenerator = new DelimitedRandom(-1, 1);

			return new NeuralNetworkBuilder(new ConnectionProperties(weightGenerator), 
											new PerceptronProperties(thresholdGenerator),
											new AcceptanceMatcher(-0.049, 0.049))
											.WithLayer(1).From(784).To(98)
											.WithLayer(2).From(98).To(1)
											.Build();
        }
	}
}