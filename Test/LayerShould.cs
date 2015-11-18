﻿using FluentAssertions;
using NUnit.Framework;


namespace Test
{
	[TestFixture]
	public class LayerShould
	{
		[Test]
		public void have_8_connections_when_built_from_2_to_4()
		{
			var layer = new Layer(2, 4);

			layer.Count().Should().Be(8);
		}

		[Test]
		public void have_the_correct_indexes()
		{
			var layer = new Layer(2, 4);

			layer.HasConnection(2, 4).Should().BeTrue();
		}

		[Test]
		public void return_the_weight_of_a_connection()
		{
			var layer = new Layer(1, 1);

			layer.Connection(1, 1).Weight.Should().Be(1.0);
		}

		[Test]
		public void set_a_connection_for_a_weight()
		{
			var layer = new Layer(1, 1);

			layer.Connection(1, 1).Weight = 0.0;

			layer.Connection(1, 1).Weight.Should().Be(0.0);
		}
	}
}