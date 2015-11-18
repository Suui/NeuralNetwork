using System;
using FluentAssertions;
using NUnit.Framework;
using Source.Layers;


namespace Test
{
	[TestFixture]
	public class LayerListShould
	{
		[Test]
		public void be_built_with_the_correct_indexes()
		{
			LayerList layers = new LayerList()
									.With(new Layer(3, 4))
									.With(new Layer(4, 4))
									.With(new Layer(4, 2));

			layers = new LayerList()
							.WithLayer(1).From(3).To(4)
							.WithLayer(2).From(4).To(4)
							.WithLayer(3).From(4).To(2);

			layers.Haslayer(0).Should().BeFalse();
			layers.Haslayer(3).Should().BeTrue();
		}

		[Test]
		public void return_layers_with_their_correct_indexes()
		{
			LayerList layers = new LayerList()
									.With(new Layer(3, 4))
									.With(new Layer(4, 4))
									.With(new Layer(4, 2));

			Assert.Throws<ArgumentOutOfRangeException>(() => layers[0].Count());
			layers[1].Count().Should().Be(12);
			layers[2].Count().Should().Be(16);
			layers[3].Count().Should().Be(8);
			Assert.Throws<ArgumentOutOfRangeException>(() => layers[4].Count());
		}
	}
}