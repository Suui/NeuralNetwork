using System.Collections.Generic;
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

			layers.Haslayer(0).Should().BeFalse();
			layers.Haslayer(3).Should().BeTrue();
		}
	}

	public class LayerList
	{
		public List<Layer> Layers { get; set; }

		public LayerList()
		{
			Layers = new List<Layer>();
		}

		public LayerList With(Layer layer)
		{
			Layers.Add(layer);
			return this;
		}

		public bool Haslayer(int index)
		{
			if (index - 1 < 0) return false;

			return Layers.Count >= index - 1;
		}
	}
}