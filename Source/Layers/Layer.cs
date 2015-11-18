using Source.Layers.Connections;


namespace Source.Layers
{
	public class Layer
	{
		public ConnectionList Connections { get; }
		public PerceptronList Perceptrons { get; }
		public int Index { get; }

		public Layer(int leftPerceptrons, int rightPerceptrons)
		{
			Connections = ConnectionListBuilder.Build(leftPerceptrons, rightPerceptrons);
		}

		public Layer(int index, int leftPerceptrons, int rightPerceptrons)
		{
			Connections = ConnectionListBuilder.Build(leftPerceptrons, rightPerceptrons);
			Index = index;
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

		public Perceptron Perceptron(int index)
		{
			throw new System.NotImplementedException();
		}
	}

	public class PerceptronList
	{

	}
}