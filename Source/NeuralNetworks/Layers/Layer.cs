using Source.NeuralNetworks.Layers.Connections;
using Source.NeuralNetworks.Layers.Perceptrons;


namespace Source.NeuralNetworks.Layers
{
	public class Layer
	{
		private ConnectionList Connections { get; }
		public PerceptronList Perceptrons { get; }
		public int CountPerceptrons => Perceptrons.Count;
		public int CountConnections => Connections.Count;

		public Layer(LayerProperties layerProperties) 
		{
			Connections = ConnectionListBuilder.Build(layerProperties.LeftPerceptrons, layerProperties.RightPerceptrons, layerProperties.ConnectionProperties);
			Perceptrons = PerceptronListBuilder.Build(layerProperties.LeftPerceptrons, layerProperties.PerceptronProperties);
		}

		public Connection Connection(int from, int to)
		{
			return Connections[from, to];
		}

		public bool HasConnection(int from, int to)
		{
			return Connections.ContainsKey(from, to);
		}

		public EntryPerceptron Perceptron(int index)
		{
			return Perceptrons[index - 1];
		}
	}
}