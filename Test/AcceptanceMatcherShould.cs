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
			_acceptanceMatcher.IsValue(0).AcceptedForExpectedValue(0).Should().BeTrue();
		}

		[Test]
		public void return_true_when_passed_a_number_at_the_above_distance()
		{
			_acceptanceMatcher.IsValue(2.049).AcceptedForExpectedValue(2).Should().BeTrue();
		}
	}
}