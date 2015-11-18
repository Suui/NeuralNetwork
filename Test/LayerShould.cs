using FluentAssertions;
using NUnit.Framework;


namespace Test
{
	[TestFixture]
	public class LayerShould
	{
		[Test]
		public void have_8_connections_when_built_with_2_and_4()
		{
			var layer = new Layer(2, 4);

			layer.GetConnections().Count().Should().Be(8);
		}

		[Test]
		public void have_the_correct_indexes()
		{
			var layer = new Layer(2, 4);

			layer.GetConnections().ContainsKey(new Connection(2, 4)).Should().BeTrue();
		}
	}
}