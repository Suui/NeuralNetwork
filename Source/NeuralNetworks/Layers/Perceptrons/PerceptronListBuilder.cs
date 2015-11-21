using System.Collections.Generic;


namespace Source.NeuralNetworks.Layers.Perceptrons
{
	public class PerceptronListBuilder
	{
		public static PerceptronList Build(int numberOfPerceptrons, PerceptronProperties perceptronProperties)
		{
			return perceptronProperties.IsEntryPerceptronList ? EntryPerceptronList(numberOfPerceptrons)
															  : PerceptronList(numberOfPerceptrons, perceptronProperties);
		}

		private static PerceptronList EntryPerceptronList(int numberOfPerceptrons)
		{
			var perceptrons = new List<Perceptron>();

			for (var i = 0; i < numberOfPerceptrons; i++)
				perceptrons.Add(new EntryPerceptron(i + 1));

			return new PerceptronList(perceptrons);
		}

		private static PerceptronList PerceptronList(int numberOfPerceptrons, PerceptronProperties perceptronProperties)
		{
			var perceptrons = new List<Perceptron>();

			for (var i = 0; i < numberOfPerceptrons; i++)
				perceptrons.Add(new Perceptron(i + 1, perceptronProperties));

			return new PerceptronList(perceptrons);
		}
	}
}