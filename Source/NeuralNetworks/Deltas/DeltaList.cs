using System.Collections.Generic;


namespace Source.NeuralNetworks.Deltas
{
	public class DeltaList
	{
		private readonly List<Delta> _deltaList;

		public DeltaList(int capacity)
		{
			_deltaList = new List<Delta>();

			for (var i = 0; i < capacity; i++)
				_deltaList.Add(new Delta());
		}

		public Delta Delta(int index)
		{
			return _deltaList[index - 1];
		}
	}
}