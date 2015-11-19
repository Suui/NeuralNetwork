using FluentAssertions;
using NUnit.Framework;
using Source;


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
	}
}