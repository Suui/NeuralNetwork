using System;
using Source.Exceptions;


namespace Source.NumberGenerators
{
	public class DelimitedRandom : NumberGenerator
	{
		private static Random _random;
		private readonly double _minValue;
		private readonly double _maxValue;

		public DelimitedRandom(double minValue, double maxValue)
		{
			if (minValue > maxValue) throw new UnvalidDelimiterException();
			_random = new Random();
			_minValue = minValue;
			_maxValue = maxValue;
		}

		public override double Generate()
		{
			return _random.NextDouble() * (_maxValue - _minValue) + _minValue;
		}
	}
}