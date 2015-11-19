using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Source.NeuralNetworks;
using Source.NeuralNetworks.Layers.Perceptrons;


namespace Test
{
	[TestFixture]
	public class NeuralNetworkShould
	{
		[Test]
		public void return_an_exit_value_of_0_by_default_when_it_has_no_hidden_layers()
		{
			var neuralNetwork = new NeuralNetworkBuilder().Build()
														  .WithLayer(1).From(1).To(1)
														  .Get();

			neuralNetwork.Execute();

			neuralNetwork.ExitValues[0].Should().Be(0.0);
		}

		[Test]
		public void return_an_exit_value_of_1_when_perceptrons_have_a_very_high_threshold()
		{
			var thresholdRandomizer = Substitute.For<ThresholdRandomizer>();
			thresholdRandomizer.GetThreshold().Returns(9999);
			var neuralNetwork = new NeuralNetworkBuilder().Build()
														  .WithLayer(1).From(1).To(1)
														  .WithLayer(2).From(1).To(1)
														  .Get();

			neuralNetwork.Execute();

			neuralNetwork.ExitValues[0].Should().Be(1.0);
		}
	}
}