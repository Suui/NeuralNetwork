using System.Collections;
using System.Collections.Generic;


namespace Source.Layers.Perceptrons
{
	public class PerceptronList : IEnumerable
	{
		private readonly List<Perceptron> _perceptrons;
		public int Count => _perceptrons.Count;

		public PerceptronList(List<Perceptron> perceptrons)
		{
			_perceptrons = perceptrons;
		}

		public Perceptron this[int index] => _perceptrons[index];

		public IEnumerator GetEnumerator()
		{
			return _perceptrons.GetEnumerator();
		}
	}
}