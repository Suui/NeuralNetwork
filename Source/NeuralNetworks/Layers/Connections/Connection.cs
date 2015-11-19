namespace Source.NeuralNetworks.Layers.Connections
{
	public class Connection
	{
		public int From { get; }
		public int To { get; }
		public double Weight { get; set; }

		public Connection(int from, int to)
		{
			From = from;
			To = to;
			Weight = 1.0;
		}
	}
}