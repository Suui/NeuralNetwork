namespace Source.AcceptanceMatchers
{
	public class AcceptanceMatcher
	{
		private readonly double _belowDistance;
		private readonly double _aboveDistance;
		private double _expectedValue;
		private double _value;

		public AcceptanceMatcher(double belowDistance, double aboveDistance)
		{
			_belowDistance = belowDistance;
			_aboveDistance = aboveDistance;
		}

		public AcceptanceMatcher ForExpectedValue(double expectedValue)
		{
			_expectedValue = expectedValue;
			return this;
		}

		public AcceptanceMatcher IsValue(double value)
		{
			_value = value;
			return this;
		}

		public bool Accepted()
		{
			return _value <= _expectedValue + _aboveDistance && _value >= _expectedValue + _belowDistance;
		}
	}
}