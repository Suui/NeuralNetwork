using System;


namespace Source.Exceptions
{
	public class UnvalidDelimiterException : Exception
	{
		public UnvalidDelimiterException() : base("Unvalid range for DelimitedRandom, minValue must be <= maxValue")
		{
		}
	}
}