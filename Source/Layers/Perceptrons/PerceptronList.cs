using System.Collections.Generic;


namespace Source.Layers.Perceptrons
{
	public class PerceptronList
	{
		private readonly List<Perceptron> _perceptrons;

		public PerceptronList(List<Perceptron> perceptrons)
		{
			_perceptrons = perceptrons;
		}

		public Perceptron this[int index] => _perceptrons[index];
	}
}