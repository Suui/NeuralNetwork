using NUnit.Framework;
using FluentAssertions;


namespace Test
{
	[TestFixture]
	public class PerceptronShould
	{
		[Test]
		public void return_0_by_default()
		{
			Perceptron perceptron = new Perceptron();

			perceptron.ExitValue().Should().Be(0);
		}
	}

	public class Perceptron
	{
		public int ExitValue()
		{
			return 0;
		}
	}
}