

namespace Test
{
	public class Layer
	{
		public ConnectionDictionary Connections { get; }

		public Layer(int leftPerceptrons, int rightPerceptrons)
		{
			Connections = ConnectionDictionaryBuilder.Build(leftPerceptrons, rightPerceptrons);
		}

		public Weight WeightForConnection(Connection connection)
		{
			return Connections[connection];
		}

		public void SetWeightForConnection(Connection connection, Weight weight)
		{
			Connections[connection] = weight;
		}
	}
}