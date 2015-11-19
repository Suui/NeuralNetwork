using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Source.NeuralNetworks.Layers;


namespace Test
{
	[TestFixture]
	public class LayerDictionaryShould
	{
		public LayerDictionary Layers { get; set; }

		[SetUp]
		public void given_a_layer_list_with_3_layers()
		{
			Layers = new TestLayerDictionaryBuilder().Build()
												 .WithLayer(1).From(3).To(4)
												 .WithLayer(2).From(4).To(4)
												 .WithLayer(3).From(4).To(2)
												 .Get();
		}

		[Test]
		public void be_built_with_the_correct_indexes()
		{
			Layers.HasLayer(0).Should().BeFalse();
			Layers.HasLayer(3).Should().BeTrue();
		}

		[Test]
		public void return_layers_with_their_correct_indexes()
		{
			Assert.Throws<KeyNotFoundException>(() => Layers[0].Perceptron(1));
			Layers[1].CountConnections.Should().Be(12);
			Layers[2].CountConnections.Should().Be(16);
			Layers[3].CountConnections.Should().Be(8);
			Assert.Throws<KeyNotFoundException>(() => Layers[4].Perceptron(1));
		}
	}
}