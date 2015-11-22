﻿using Source.NeuralNetworks.Layers.Connections;
using Source.NeuralNetworks.Layers.Perceptrons;


namespace Source.NeuralNetworks.Layers
{
	public class Layer
	{
		private ConnectionList Connections { get; }
		public PerceptronList Perceptrons { get; }
		public int CountPerceptrons => Perceptrons.Count;
		public int CountConnections => Connections.Count;

		public Layer(int leftPerceptrons, int rightPerceptrons, ConnectionProperties connectionProperties, PerceptronProperties perceptronProperties)
		{
			Connections = ConnectionListBuilder.Build(leftPerceptrons, rightPerceptrons, connectionProperties);
			Perceptrons = PerceptronListBuilder.Build(leftPerceptrons, perceptronProperties);
		}

		public Layer(LayerProperties layerProperties) 
			: this(layerProperties.LeftPerceptrons, layerProperties.RightPerceptrons, layerProperties.ConnectionProperties, layerProperties.PerceptronProperties)
		{
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