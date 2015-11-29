using System;


namespace Source
{
	public class ErrorCalculator
	{
		private double _minimumSquaredError = 0.0;
		private double _numberOfResults = 0.0;

		public void AddResult(double expectedExitValue, double exitValue)
		{
			_minimumSquaredError += Math.Pow(expectedExitValue - exitValue, 2);
			_numberOfResults += 1;
		}

		public double GetMSE()
		{
			return 1 / _numberOfResults * _minimumSquaredError;
		}
	}
}