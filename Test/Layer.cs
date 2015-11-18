

namespace Test
{
	public class Layer
	{
		public ConnectionDictionary Connections { get; }

		public Layer(int leftPerceptrons, int rightPerceptrons)
		{
			Connections = ConnectionDictionaryBuilder.Build(leftPerceptrons, rightPerceptrons);
		}

		public double GetWeightForConnection(int from, int to)
		{
			return Connections[new Connection(from, to)];
		}

		public void SetWeightForConnection(int from, int to, double value)
		{
			Connections[new Connection(from, to)] = value;
		}
	}
}