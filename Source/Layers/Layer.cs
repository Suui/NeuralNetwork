using Source.Layers.Connections;


namespace Source.Layers
{
	public class Layer
	{
		public ConnectionList Connections { get; }
		public PerceptronList Perceptrons { get; }

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

	public class PerceptronList
	{

	}
}