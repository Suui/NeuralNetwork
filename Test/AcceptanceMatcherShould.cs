using FluentAssertions;
using NUnit.Framework;
using Source.AcceptanceMatchers;


/*
	TODO
	We pass a two numbers to it, an expected value and a value we are checking that is
	near enough the expected one.

	Tests
	0, 0 => true
	2, 2 => true
	2, 2 + maxDistance => true
	2, 2 - minDistance => true
	2, 2 + maxDistance + 0000.1 => false
	2, 2 - maxDistance - 0000.1 => false
*/


namespace Test
{
	[TestFixture]
	public class AcceptanceMatcherShould
	{
		private AcceptanceMatcher _acceptanceMatcher;

		[SetUp]
		public void Initialize()
		{
			_acceptanceMatcher = new AcceptanceMatcher(-0.049, 0.049);
		}

		[Test]
		public void return_true_when_passed_number_equals_expected_number()
		{
			_acceptanceMatcher.ForExpectedValue(0).IsValue(0).Accepted().Should().BeTrue();
		}

		[Test]
		public void return_true_when_passed_a_number_at_the_above_distance()
		{
			_acceptanceMatcher.ForExpectedValue(2).IsValue(2.049).Accepted().Should().BeTrue();
		}

		[Test]
		public void return_true_when_passed_a_number_below_the_above_distance()
		{
			_acceptanceMatcher.ForExpectedValue(2).IsValue(2.048).Accepted().Should().BeTrue();
		}

		[Test]
		public void return_false_when_passed_a_number_under_the_below_distance()
		{
			_acceptanceMatcher.ForExpectedValue(2).IsValue(1.0509).Accepted().Should().BeFalse();
		}
	}
}