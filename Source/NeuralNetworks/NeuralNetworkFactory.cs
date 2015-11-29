﻿using Source.NeuralNetworks.Layers.Connections;
using Source.NeuralNetworks.Layers.Perceptrons;
using Source.NumberGenerators;


namespace Source.NeuralNetworks
{
	public class NeuralNetworkFactory
	{
		public static NeuralNetwork NeuralNetworkForPracticeFour()
		{
			var weightGenerator = new DelimitedRandom(-10000, 10000);
			var thresholdGenerator = new DelimitedRandom(-10000, 10000);

			return new NeuralNetworkBuilder(new ConnectionProperties(weightGenerator), new PerceptronProperties(thresholdGenerator))
						.WithLayer(1).From(784).To(49)
						.WithLayer(2).From(49).To(1)
						.Build();
        }
	}
}