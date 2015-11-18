namespace Source.Layers.Perceptrons
{
	public class Perceptron
	{
		private Layer PreviousLayer { get; }
		protected int Index { get; set; }
		public double U { get; set; }

		protected Perceptron() {}

		public Perceptron(int index, Layer previousLayer)
		{
			PreviousLayer = previousLayer;
			Index = index;
			U = 1.0;
		}

		public virtual double ExitValue()
		{
			return U + PreviousLayer.Connection(1, Index).Weight * PreviousLayer.Perceptron(1).ExitValue()
					 + PreviousLayer.Connection(2, Index).Weight * PreviousLayer.Perceptron(2).ExitValue();
		}
	}

	public class EntryPerceptron : Perceptron
	{
		private double EntryValue { get; set; }

		public EntryPerceptron(int index)
		{
			Index = index;
		}

		public override double ExitValue()
		{
			return EntryValue;
		}
	}
}