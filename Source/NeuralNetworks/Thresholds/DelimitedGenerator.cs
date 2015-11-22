using System;


namespace Source.NeuralNetworks.Thresholds
{
	public class DelimitedGenerator : RandomGenerator
	{
		private static Random _random;
		private readonly double _minValue;
		private readonly double _maxValue;

		public DelimitedGenerator(double minValue, double maxValue)
		{
			_random = new Random();
			_minValue = minValue;
			_maxValue = maxValue;
		}

		public override double Generate()
		{
			throw new System.NotImplementedException();
		}
	}
}