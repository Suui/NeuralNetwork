using System.Collections;
using System.Collections.Generic;


namespace Source.NeuralNetworks.Layers.Perceptrons
{
	public class PerceptronList : IEnumerable
	{
		private readonly List<InnerPerceptron> _perceptrons;
		public int Count => _perceptrons.Count;

		public PerceptronList(List<InnerPerceptron> perceptrons)
		{
			_perceptrons = perceptrons;
		}

		public InnerPerceptron this[int index] => _perceptrons[index];

		public IEnumerator GetEnumerator()
		{
			return _perceptrons.GetEnumerator();
		}
	}
}