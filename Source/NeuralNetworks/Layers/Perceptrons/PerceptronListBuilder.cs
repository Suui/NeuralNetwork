﻿using System;
using System.Collections.Generic;


namespace Source.NeuralNetworks.Layers.Perceptrons
{
	public class PerceptronListBuilder
	{
		private static PerceptronList EntryPerceptronList(int numberOfPerceptrons)
		{
			var perceptrons = new List<Perceptron>();

			for (var i = 0; i < numberOfPerceptrons; i++)
				perceptrons.Add(new EntryPerceptron(i));

			return new PerceptronList(perceptrons);
		}

		public static PerceptronList Build(int numberOfPerceptrons, PerceptronProperties perceptronProperties)
		{
			return perceptronProperties.IsEntryPerceptronList ? EntryPerceptronList(numberOfPerceptrons)
															  : PerceptronList(numberOfPerceptrons, perceptronProperties);
		}

		private static PerceptronList PerceptronList(int numberOfPerceptrons, PerceptronProperties perceptronProperties)
		{
			var perceptrons = new List<Perceptron>();

			for (var i = 0; i < numberOfPerceptrons; i++)
				perceptrons.Add(new Perceptron(i, perceptronProperties));

			return new PerceptronList(perceptrons);
		}
	}
}