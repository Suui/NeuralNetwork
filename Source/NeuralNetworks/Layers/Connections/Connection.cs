namespace Source.NeuralNetworks.Layers.Connections
{
	public class Connection
	{
		public int From { get; }
		public int To { get; }
		public double Weight { get; set; }

		public Connection(int from, int to, ConnectionProperties connectionProperties)
		{
			From = from;
			To = to;
			Weight = connectionProperties.WeightGenerator.Generate();
		}
	}
}