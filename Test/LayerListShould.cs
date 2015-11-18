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
}