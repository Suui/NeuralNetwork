using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Source.NeuralNetworks.Layers;
using Source.NeuralNetworks.Layers.Connections;
using Source.NeuralNetworks.Layers.Perceptrons;
using Source.NeuralNetworks.NumberGenerators;


namespace Test
{
	[TestFixture]
	public class LayerShould
	{
		private static Layer Layer { get; set; }

		[SetUp]
		public void given_a_layer_from_2_to_4()
		{
			var thresholdGenerator = Substitute.For<DelimitedRandom>(0, 0);
			var weightGenerator = Substitute.For<DelimitedRandom>(0, 0);
			weightGenerator.Generate().Returns(1.0);
			Layer = new Layer(new LayerProperties
							  {
							      LeftPerceptrons = 2,
							      RightPerceptrons = 4,
							      ConnectionProperties = new ConnectionProperties(weightGenerator),
							      PerceptronProperties = new PerceptronProperties(thresholdGenerator)
							  });
		}

		[Test]
		public void have_8_connections_when_built_from_2_to_4()
		{
			Layer.CountConnections.Should().Be(8);
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
			Layer.Perceptron(1).Should().NotBeNull();
			Layer.Perceptron(2).Should().NotBeNull();
			Assert.Throws<ArgumentOutOfRangeException>(() => Layer.Perceptron(3));
		}
	}
}