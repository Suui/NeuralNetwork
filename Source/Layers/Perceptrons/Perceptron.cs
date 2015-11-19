using System;

namespace Source.Layers.Perceptrons
{
	public class Perceptron
	{
		private Layer PreviousLayer { get; }
		protected int Index { get; set; }
		public double Threshold { get; set; }

		protected Perceptron() {}

		public Perceptron(int index, Layer previousLayer)
		{
			PreviousLayer = previousLayer;
			Index = index;
			Threshold = 1.0;
		}

		public virtual double ExitValue()
		{
			double x = Threshold + Summation(1, PreviousLayer.CountPerceptrons);

			return Sigmoide(x);
		}

		private double Summation(int from, int to)
		{
			var result = 0.0;

			for (var j = from; j < to; j++)
				result += PreviousLayer.Perceptron(j).ExitValue() * PreviousLayer.Connection(j, Index).Weight;

			return result;
		}

		public double Sigmoide(double x)
		{
			return 1 / (1 + Math.Pow(Math.E, -x));
		}
	}

	public class EntryPerceptron : Perceptron
	{
		private double EntryValue { get; set; }

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