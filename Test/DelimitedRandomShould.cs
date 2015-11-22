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
	}
}