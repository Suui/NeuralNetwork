using System.Collections.Generic;


namespace Source.Layers.Perceptrons
{
	public class PerceptronListBuilder
	{
		public static PerceptronList Build(int numberOfPerceptrons, Layer previousLayer)
		{
			var perceptrons = new List<Perceptron>();

			if (previousLayer == null)
			{
				for (var i = 0; i < numberOfPerceptrons; i++)
					perceptrons.Add(new EntryPerceptron(i));
			}
			else
			{
				for (var i = 0; i < numberOfPerceptrons; i++)
					perceptrons.Add(new Perceptron(i, previousLayer));
			}
			return new PerceptronList(perceptrons);
		}
	}
}