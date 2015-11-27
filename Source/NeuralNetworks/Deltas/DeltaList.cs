using System.Collections.Generic;
using System.Linq;


namespace Source.NeuralNetworks.Deltas
{
	public class DeltaList
	{
		private readonly List<Delta> _deltaList;

		public DeltaList(int capacity)
		{
			_deltaList = Enumerable.Repeat(new Delta(), capacity).ToList();
		}

		public Delta Delta(int index)
		{
			return _deltaList[index - 1];
		}
	}
}