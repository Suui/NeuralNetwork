

namespace Test
{
	public class Layer
	{
		public ConnectionDictionary Connections { get; }

		public Layer(int leftPerceptrons, int rightPerceptrons)
		{
			Connections = ConnectionDictionaryBuilder.Build(leftPerceptrons, rightPerceptrons);
		}

		{
		}

		public double GetWeightForConnection(int from, int to)
		{
			return Connections[new Connection(from, to)];
		}
	}
}