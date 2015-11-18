using NUnit.Framework;
using FluentAssertions;
using Source;
using Source.Layers;
using Source.Layers.Perceptrons;


namespace Test
{
	[TestFixture]
	public class PerceptronShould
	{
		[Test]
		public void return_1_by_default()
		{
			var perceptron = new Perceptron(0, new Layer(1, 2));

			perceptron.ExitValue().Should().Be(1.0);
		}
	}
}