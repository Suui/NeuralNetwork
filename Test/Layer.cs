

namespace Test
{
	public class Layer
	{
		private ConnectionDictionary Connections { get; }

		public Layer(int leftPerceptrons, int rightPerceptrons)
		{
			Connections = ConnectionDictionaryBuilder.Build(leftPerceptrons, rightPerceptrons);
		}

		public ConnectionDictionary GetConnections()
		{
			return Connections;
		}

		public double GetWeightForConnection(int from, int to)
		{
			return Connections[new Connection(from, to)];
		}
	}
}