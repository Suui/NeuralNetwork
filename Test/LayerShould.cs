using System;
using FluentAssertions;
using NUnit.Framework;
using Source.Layers;


namespace Test
{
	[TestFixture]
	public class LayerShould
	{
		private static Layer Layer { get; set; }

		[SetUp]
		public void given_a_layer_from_2_to_4()
		{
			Layer = new Layer(2, 4);
		}

		[Test]
		public void have_8_connections_when_built_from_2_to_4()
		{
			Layer.Count().Should().Be(8);
		}

		[Test]
		public void have_the_correct_indexes()
		{
			Layer.HasConnection(0, 0).Should().BeFalse();
			Layer.HasConnection(2, 4).Should().BeTrue();
		}

		[Test]
		public void return_the_weight_of_a_connection()
		{
			Layer.Connection(1, 1).Weight.Should().Be(1.0);
		}

		[Test]
		public void set_a_connection_for_a_weight()
		{
			Layer.Connection(1, 1).Weight = 0.0;

			Layer.Connection(1, 1).Weight.Should().Be(0.0);
		}

		[Test]
		public void get_a_perceptron_with_correct_indexes()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => Layer.Perceptron(0));
			Layer.Perceptron(1).ExitValue().Should().Be(0.0);
		}
	}
}