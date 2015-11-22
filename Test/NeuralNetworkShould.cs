﻿using System.Collections.Generic;
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
		private RandomGenerator _thresholdGenerator;

		[SetUp]
		public void given_a_threshold_generator()
		{
			_thresholdGenerator = Substitute.For<DelimitedGenerator>(0, 0);
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
		public void return_0_point_5_when_it_has_no_hidden_layers_entry_value_is_0_threshold_is_0_and_weight_is_1()
		{
			_thresholdGenerator.Generate().Returns(0.0);
			var neuralNetwork = new NeuralNetworkBuilder(new PerceptronProperties(_thresholdGenerator))
								.WithLayer(1).From(1).To(1)
								.Build();

			neuralNetwork.EntryValues = new List<double> { 0.0 };
			neuralNetwork.Execute();

			neuralNetwork.ExitValues[0].Should().Be(0.5);
		}

		[Test]
		public void return_0_point_26894142_when_it_has_no_hidden_layers_entry_values_are_2_and_4_threshold_is_minus7_and_weights_are_1()
		{
			_thresholdGenerator.Generate().Returns(-7.0);
			var neuralNetwork = new NeuralNetworkBuilder(new PerceptronProperties(_thresholdGenerator))
								.WithLayer(1).From(2).To(1)
								.Build();

			neuralNetwork.EntryValues = new List<double> { 2.0, 4.0 };
			neuralNetwork.Execute();

			neuralNetwork.ExitValues[0].Should().BeApproximately(0.26894142, 0.00000001);
		}
	}
}