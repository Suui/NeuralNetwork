using Source.Layers;

namespace Source
{
	public class Perceptron
	{
		private Layer PreviousLayer { get; set; }
		private int Index { get; }
		public double U { get; }

		public Perceptron(int index, Layer previousLayer)
		{
			Index = index;
			U = 1.0;
		}

		public double ExitValue()
		{
			return U;
			//return U + PreviousLayer.Connection(1, Index).Weight * PreviousLayer.Perceptron(1).ExitValue()
			//		 + PreviousLayer.Connection(2, Index).Weight * PreviousLayer.Perceptron(2).ExitValue();
		}

	}
}