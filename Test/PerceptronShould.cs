using NUnit.Framework;
using FluentAssertions;


namespace Test
{
	[TestFixture]
	public class PerceptronShould
	{
		[Test]
		public void return_1_by_default()
		{
			Perceptron perceptron = new Perceptron();

			perceptron.ExitValue().Should().Be(1);
		}
	}

	public class Perceptron
	{
		public int ExitValue()
		{
			return 1;
		}
	}
}