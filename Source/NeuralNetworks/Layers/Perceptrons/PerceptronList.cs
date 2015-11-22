using System.Collections;
using System.Collections.Generic;


namespace Source.NeuralNetworks.Layers.Perceptrons
{
	public class PerceptronList : IEnumerable
	{
		private readonly List<EntryPerceptron> _perceptrons;
		public int Count => _perceptrons.Count;

		public PerceptronList(List<EntryPerceptron> perceptrons)
		{
			_perceptrons = perceptrons;
		}

		public EntryPerceptron this[int index] => _perceptrons[index];

		public IEnumerator GetEnumerator()
		{
			return _perceptrons.GetEnumerator();
		}
	}
}