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
			var layers = new LayerList()
								.WithLayer(1).From(3).To(4)
								.WithLayer(2).From(4).To(4)
								.WithLayer(3).From(4).To(2);

			var builtLayerList = new LayerListBuilder().Build()
													   .WithLayer(1).From(3).To(4)
													   .WithLayer(2).From(4).To(4)
													   .WithLayer(3).From(4).To(2)
													   .Get();

			layers.Haslayer(0).Should().BeFalse();
			layers.Haslayer(3).Should().BeTrue();
		}

		[Test]
		public void return_layers_with_their_correct_indexes()
		{
			var layers = new LayerList()
								.WithLayer(1).From(3).To(4)
								.WithLayer(2).From(4).To(4)
								.WithLayer(3).From(4).To(2);

			Assert.Throws<ArgumentOutOfRangeException>(() => layers[0].Count());
			layers[1].Count().Should().Be(12);
			layers[2].Count().Should().Be(16);
			layers[3].Count().Should().Be(8);
			Assert.Throws<ArgumentOutOfRangeException>(() => layers[4].Count());
		}
	}

	public class LayerListBuilder
	{
		private readonly LayerList _layerList;
		private int _index;
		private int _leftPerceptrons;

		public LayerListBuilder()
		{
			_layerList = new LayerList();
		}

		public LayerListBuilder Build()
		{
			return this;
		}

		public LayerListBuilder WithLayer(int index)
		{
			_index = index;
			return this;
		}

		public LayerListBuilder From(int leftPerceptrons)
		{
			_leftPerceptrons = leftPerceptrons;
			return this;
		}

		public LayerListBuilder To(int rightPerceptrons)
		{
			var layer = new Layer(_index, _leftPerceptrons, rightPerceptrons);
			_layerList.Layers.Add(layer);
			return this;
		}

		public LayerList Get()
		{
			return _layerList;
		}
	}
}