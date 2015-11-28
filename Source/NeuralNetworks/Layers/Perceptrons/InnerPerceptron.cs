using Source.Formulas;


namespace Source.NeuralNetworks.Layers.Perceptrons
{
	public class Perceptron
	{
		protected int Index { get; set; }
		public double EntryValue { get; set; }
		public double DerivativeError { get; set; }

		public Perceptron(int index)
		{
			Index = index;
			EntryValue = 0.0;
		}

		public virtual double ExitValue()
		{
			return EntryValue;
		}
	}

	public class InnerPerceptron : Perceptron
	{
		private Layer PreviousLayer { get; }
		private Formula Formula { get; }
		public double Threshold { get; set; }

		public InnerPerceptron(int index, PerceptronProperties perceptronProperties) : base(index)
		{
			Index = index;
			PreviousLayer = perceptronProperties.PreviousLayer;
			Threshold = perceptronProperties.ThresholdGenerator.Generate();
			Formula = new Sigmoid();
		}

		public override double ExitValue()
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
}