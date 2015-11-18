using Source.Layers.Connections;
using Source.Layers.Perceptrons;


namespace Source.Layers
{
	public class Layer
	{
		public ConnectionList Connections { get; }
		public PerceptronList Perceptrons { get; }

		public Layer(int leftPerceptrons, int rightPerceptrons)
		{
			Connections = ConnectionListBuilder.Build(leftPerceptrons, rightPerceptrons);
			Perceptrons = PerceptronListBuilder.Build(leftPerceptrons, null);
		}

		public Layer(int leftPerceptrons, int rightPerceptrons, Layer previousLayer)
		{
			Connections = ConnectionListBuilder.Build(leftPerceptrons, rightPerceptrons);
			Perceptrons = PerceptronListBuilder.Build(leftPerceptrons, previousLayer);
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
}