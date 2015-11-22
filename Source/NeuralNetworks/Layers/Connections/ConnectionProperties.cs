using Source.NeuralNetworks.NumberGenerators;


namespace Source.NeuralNetworks.Layers.Connections
{
	public class ConnectionProperties
	{
		public NumberGenerator WeightGenerator { get; }

		public ConnectionProperties(NumberGenerator weightGenerator)
		{
			WeightGenerator = weightGenerator;
		}
	}
}