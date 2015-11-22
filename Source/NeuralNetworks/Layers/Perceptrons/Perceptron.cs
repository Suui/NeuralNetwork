using Source.Formulas;


namespace Source.NeuralNetworks.Layers.Perceptrons
{
	public class Perceptron
	{
		private Layer PreviousLayer { get; }
		private Formula Formula { get; }
		protected int Index { get; set; }
		public double Threshold { get; set; }

		protected Perceptron() {}

		public Perceptron(int index, PerceptronProperties perceptronProperties)
		{
			Index = index;
			PreviousLayer = perceptronProperties.PreviousLayer;
			Threshold = perceptronProperties.ThresholdGenerator.Generate();
			Formula = new Sigmoid();
		}

		public virtual double ExitValue()
		{
			var x = Threshold + Summation(1, PreviousLayer.CountPerceptrons);

			return Formula.CalculateFor(x);
		}

		private double Summation(int from, int to)
		{
			var result = 0.0;

			for (var j = from; j <= to; j++)
				result += PreviousLayer.Perceptron(j).ExitValue() * PreviousLayer.Connection(j, Index).Weight;

			return result;
		}
	}

	public class EntryPerceptron : Perceptron
	{
		public double EntryValue { get; set; }

		public EntryPerceptron(int index)
		{
			Index = index;
			EntryValue = 0.0;
		}

		public override double ExitValue()
		{
			return EntryValue;
		}
	}
}