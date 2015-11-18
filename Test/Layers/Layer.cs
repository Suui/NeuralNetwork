using Test.Layers.Connections;

namespace Test.Layers
{
	public class Layer
	{
		public ConnectionList Connections { get; }

		public Layer(int leftPerceptrons, int rightPerceptrons)
		{
			Connections = ConnectionListBuilder.Build(leftPerceptrons, rightPerceptrons);
		}

		public Connection Connection(int from, int to)
		{
			return Connections[from, to];
		}

		public bool HasConnection(int from, int to)
		{
			return Connections.ContainsKey(from, to);
		}

		public int Count()
		{
			return Connections.Count();
		}
	}
}