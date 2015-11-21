using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Source.NeuralNetworks;
using Source.NeuralNetworks.Layers.Perceptrons;
using Source.NeuralNetworks.Thresholds;


namespace Test
{
	[TestFixture]
	public class NeuralNetworkShould
	{
		private ThresholdGenerator _thresholdGenerator;

		[SetUp]
		public void given_a_threshold_generator()
		{
			_thresholdGenerator = Substitute.For<DelimitedThreshold>(0, 0);
		}

		[Test]
		public void return_an_exit_value_of_1_when_perceptrons_have_a_very_high_threshold()
		{
			_thresholdGenerator.Generate().Returns(9999.0);
			var neuralNetwork = new NeuralNetworkBuilder(new PerceptronProperties(_thresholdGenerator))
								.WithLayer(1).From(1).To(1)
								.WithLayer(2).From(1).To(1)
								.Build();

			neuralNetwork.Execute();

			neuralNetwork.ExitValues[0].Should().Be(1.0);
		}

		[Test]
		public void return_an_exit_value_of_0_when_perceptrons_have_a_very_low_threshold()
		{
			_thresholdGenerator.Generate().Returns(-9999.0);
			var neuralNetwork = new NeuralNetworkBuilder(new PerceptronProperties(_thresholdGenerator))
								.WithLayer(1).From(1).To(1)
								.WithLayer(2).From(1).To(1)
								.Build();

			neuralNetwork.Execute();

			neuralNetwork.ExitValues[0].Should().Be(0.0);
		}

		[Test]
		public void return_the_correct_exit_with_the_given_entry_values()
		{
			_thresholdGenerator.Generate().Returns(0.0);
			var neuralNetwork = new NeuralNetworkBuilder(new PerceptronProperties(_thresholdGenerator))
								.WithLayer(1).From(1).To(1)
								.Build();

			neuralNetwork.EntryValues = new List<double> {1.0};
			neuralNetwork.Execute();

			neuralNetwork.ExitValues[0].Should().Be(0.5);
		}
	}
}