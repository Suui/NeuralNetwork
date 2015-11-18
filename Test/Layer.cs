

namespace Test
{
	public class Layer
	{
		public ConnectionDictionary Connections { get; }

		public Layer(int leftPerceptrons, int rightPerceptrons)
		{
			Connections = ConnectionDictionaryBuilder.Build(leftPerceptrons, rightPerceptrons);
		}

		public double GetWeightForConnection(Connection connection)
		{
			return Connections[connection];
		}

		public void SetWeightForConnection(Connection connection, double value)
		{
			Connections[connection] = value;
		}

		public void SetWeightForConnection(int from, int to, double value)
		{
			Connections[new Connection(from, to)] = value;
		}
	}
}