using FluentAssertions;
using NUnit.Framework;
using Source.NumberGenerators;


namespace Test
{
	[TestFixture]
	public class DelimitedRandomShould
	{
		[Test]
		public void return_0_when_delimited_between_0_and_0()
		{
			var delimitedRandom = new DelimitedRandom(0, 0);

			delimitedRandom.Generate().Should().Be(0.0);
		}

		[Test]
		public void return_5_when_bewteen_5_and_5()
		{
			var delimitedRandom = new DelimitedRandom(5, 5);

			delimitedRandom.Generate().Should().Be(5.0);
		}
	}
}