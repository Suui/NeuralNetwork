using System;
using Source.AcceptanceMatchers;


namespace Source.NeuralNetworks
{
	public class ErrorCalculator
	{
		private double _minimumSquaredError = 0.0;
		private double _numberOfResults = 0.0;
		private readonly AcceptanceMatcher _acceptanceMatcher = new AcceptanceMatcher(-0.049, 0.049);

		public void AddResult(double expectedExitValue, double exitValue)
		{
			_minimumSquaredError += _acceptanceMatcher
									.ForExpectedValue(expectedExitValue)
									.IsValue(exitValue).Accepted() ? 0.0
																   : Math.Pow(expectedExitValue - exitValue, 2);
			_numberOfResults += 1;
		}

		public double GetMSE()
		{
			return 1 / _numberOfResults * _minimumSquaredError;
		}
	}
}