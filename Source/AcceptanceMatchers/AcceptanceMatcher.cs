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

		public AcceptanceMatcher IsValue(double value)
		{
			_value = value;
			return this;
		}

		public bool AcceptedForExpectedValue(double expectedValue)
		{
			if (_value == expectedValue) return true;
			if (_value == expectedValue + _aboveDistance) return true;
			return false;
		}

		public AcceptanceMatcher ForExpectedValue(double expectedValue)
		{
			_expectedValue = expectedValue;
			return this;
		}

		public bool Accepted()
		{
			if (_value == _expectedValue) return true;
			return false;
		}
	}
}