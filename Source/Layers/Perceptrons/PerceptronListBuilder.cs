using System.Collections.Generic;


namespace Source.Layers.Perceptrons
{
	public class PerceptronListBuilder
	{
		public static PerceptronList Build(int numberOfPerceptrons, Layer previousLayer)
		{
			return previousLayer == null ? EntryPerceptronList(numberOfPerceptrons)
										 : PerceptronList(numberOfPerceptrons, previousLayer);
		}

		private static PerceptronList PerceptronList(int numberOfPerceptrons, Layer previousLayer)
		{
			var perceptrons = new List<Perceptron>();

			for (var i = 0; i < numberOfPerceptrons; i++)
				perceptrons.Add(new Perceptron(i, previousLayer));

			return new PerceptronList(perceptrons);
		}

		private static PerceptronList EntryPerceptronList(int numberOfPerceptrons)
		{
			var perceptrons = new List<Perceptron>();

			for (var i = 0; i < numberOfPerceptrons; i++)
				perceptrons.Add(new EntryPerceptron(i));

			return new PerceptronList(perceptrons);
		}
	}
}