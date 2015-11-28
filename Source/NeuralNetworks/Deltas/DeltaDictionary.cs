using System.Collections.Generic;


namespace Source.NeuralNetworks.Deltas
{
	public class DeltaDictionary
	{
		private Dictionary<int, DeltaList> Deltas { get; }

		public DeltaDictionary()
		{
			Deltas = new Dictionary<int, DeltaList>();
		}

		public void Add(int index, DeltaList deltaList)
		{
			Deltas.Add(index, deltaList);
		}

		public DeltaList this[int index] => Deltas[index];
	}
}