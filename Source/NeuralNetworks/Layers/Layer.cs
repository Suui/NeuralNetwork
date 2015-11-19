using Source.NeuralNetworks.Layers.Connections;
using Source.NeuralNetworks.Layers.Perceptrons;


namespace Source.NeuralNetworks.Layers
{
	public class Layer
	{
		public ConnectionList Connections { get; }
		public PerceptronList Perceptrons { get; }
		public int CountPerceptrons => Perceptrons.Count;
		public int CountConnections => Connections.Count;

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

		public Perceptron Perceptron(int index)
		{
			return Perceptrons[index - 1];
		}
	}
}