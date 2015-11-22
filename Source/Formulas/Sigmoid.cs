using System;


namespace Source.Formulas
{
	public class Sigmoid : Formula
	{
		public override double CalculateFor(double x)
		{
			return FSigmoid(x);
		}

		public double FSigmoid(double x)
		{
			return 1 / (1 + Math.Pow(Math.E, -x));
		}
	}
}