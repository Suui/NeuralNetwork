using NUnit.Framework;
using FluentAssertions;
using NSubstitute;


namespace Test
{
	[TestFixture]
	public class PerceptronShould
	{
		[Test]
		public void return_1_by_default()
		{
			var perceptron = new Perceptron();

			perceptron.ExitValue().Should().Be(1.0);
		}
	}

	public class Perceptron
	{
		double U { get; }

		public Perceptron()
		{
			U = 1.0;
		}

		public double ExitValue()
		{
			return U;
		}
	}
}