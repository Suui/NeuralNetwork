using System.Collections;
using System.Collections.Generic;

namespace Source.NeuralNetworks
{
	public class ValueList<T> : IEnumerable
	{
		private readonly List<T> _valueList;
		public int Count => _valueList.Count;

		public ValueList()
		{
			_valueList = new List<T>();
		}

		public T this[int index] => _valueList[index - 1];

		public IEnumerator GetEnumerator()
		{
			return _valueList.GetEnumerator();
		}

		public void Add(T value)
		{
			_valueList.Add(value);
		}
	}
}