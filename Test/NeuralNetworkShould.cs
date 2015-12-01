using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Source.AcceptanceMatchers;
using Source.NeuralNetworks;
using Source.NeuralNetworks.Layers.Connections;
using Source.NeuralNetworks.Layers.Perceptrons;
using Source.NumberGenerators;


namespace Test
{
	[TestFixture]
	public class NeuralNetworkShould
	{
		private NumberGenerator _thresholdGenerator;
		private NumberGenerator _weightGenerator;

		[SetUp]
		public void given_a_threshold_generator()
		{
			_thresholdGenerator = Substitute.For<DelimitedRandom>(0, 0);
			_weightGenerator = Substitute.For<DelimitedRandom>(0, 0);
		}

		[Test]
		public void return_an_exit_value_of_1_when_perceptrons_have_a_very_high_threshold()
		{
			_thresholdGenerator.Generate().Returns(9999.0);
			_weightGenerator.Generate().Returns(1.0);
			var neuralNetwork = new NeuralNetworkBuilder(new ConnectionProperties(_weightGenerator), 
														 new PerceptronProperties(_thresholdGenerator),
														 new AcceptanceMatcher(0.0, 0.0))
														.WithLayer(1).From(1).To(1)
														.WithLayer(2).From(1).To(1)
														.Build();

			neuralNetwork.Execute();

			neuralNetwork.ExitValues[1].Should().Be(1.0);
		}

		[Test]
		public void return_an_exit_value_of_0_when_perceptrons_have_a_very_low_threshold()
		{
			_thresholdGenerator.Generate().Returns(-9999.0);
			_weightGenerator.Generate().Returns(1.0);
			var neuralNetwork = new NeuralNetworkBuilder(new ConnectionProperties(_weightGenerator),
														 new PerceptronProperties(_thresholdGenerator),
														 new AcceptanceMatcher(0.0, 0.0))
														.WithLayer(1).From(1).To(1)
														.WithLayer(2).From(1).To(1)
														.Build();

			neuralNetwork.Execute();

			neuralNetwork.ExitValues[1].Should().Be(0.0);
		}

		[Test]
		public void return_0_point_5_when_it_has_no_hidden_layers_entry_value_is_0_threshold_is_0_and_weight_is_1()
		{
			_thresholdGenerator.Generate().Returns(0.0);
			_weightGenerator.Generate().Returns(1.0);
			var neuralNetwork = new NeuralNetworkBuilder(new ConnectionProperties(_weightGenerator),
														 new PerceptronProperties(_thresholdGenerator),
														 new AcceptanceMatcher(0.0, 0.0))
														.WithLayer(1).From(1).To(1)
														.Build();

			neuralNetwork.EntryValues = new ValueList<double> { 0.0 };
			neuralNetwork.Execute();

			neuralNetwork.ExitValues[1].Should().Be(0.5);
		}

		[Test]
		public void return_0_point_26894142_when_it_has_no_hidden_layers_entry_values_are_2_and_4_threshold_is_minus7_and_weights_are_1()
		{
			_thresholdGenerator.Generate().Returns(-7.0);
			_weightGenerator.Generate().Returns(1.0);
			var neuralNetwork = new NeuralNetworkBuilder(new ConnectionProperties(_weightGenerator),
														 new PerceptronProperties(_thresholdGenerator),
														 new AcceptanceMatcher(0.0, 0.0))
														.WithLayer(1).From(2).To(1)
														.Build();

			neuralNetwork.EntryValues = new ValueList<double> { 2.0, 4.0 };
			neuralNetwork.Execute();

			neuralNetwork.ExitValues[1].Should().BeApproximately(0.26894142, 0.00000001);
		}

		[Test]
		public void return_correct_error_value_for_an_exit_with_an_associated_expected_value()
		{
			var neuralNetwork = new NeuralNetworkBuilder(new ConnectionProperties(_weightGenerator), 
														 new PerceptronProperties(_thresholdGenerator),
														 new AcceptanceMatcher(0.0, 0.0))
														.WithLayer(1).From(1).To(1)
														.Build();

			neuralNetwork.EntryValues = new ValueList<double> { 1.0 };
			neuralNetwork.ExitValues = new ValueList<double> { 0.5 };
			neuralNetwork.ExpectedExitValues = new ValueList<double> { 0.8 };

			neuralNetwork.GetErrorForExit(1).Should().BeApproximately(-0.30000000, 0.00000001);
		}

		[Test]
		public void return_0_as_error_if_it_is_between_the_acceptance_matcher_limits()
		{
			var neuralNetwork = new NeuralNetworkBuilder(new ConnectionProperties(_weightGenerator), 
														 new PerceptronProperties(_thresholdGenerator),
														 new AcceptanceMatcher(-0.049, 0.049))
														.WithLayer(1).From(1).To(1)
														.Build();

			neuralNetwork.ExitValues = new ValueList<double> { 2.049 };
			neuralNetwork.ExpectedExitValues = new ValueList<double> { 2 };

			neuralNetwork.GetErrorForExit(1).Should().Be(0.0);
		}

		[Test]
		public void return_correct_modified_weight_for_a_single_layer()
		{
			_thresholdGenerator.Generate().Returns(0.0);
			_weightGenerator.Generate().Returns(1.0);
			var neuralNetwork = new NeuralNetworkBuilder(new ConnectionProperties(_weightGenerator), 
														 new PerceptronProperties(_thresholdGenerator),
														 new AcceptanceMatcher(0.0, 0.0))
														.WithLayer(1).From(2).To(2)
														.WithLayer(2).From(2).To(2)
														.WithLayer(3).From(2).To(2)
														.WithLayer(4).From(2).To(2)
														.Build();

			neuralNetwork.EntryValues = new ValueList<double> { 0.2, 0.4, 0.6, 0.8 };
			neuralNetwork.ExpectedExitValues = new ValueList<double> { 0.9, 0.6, 0.3, 0.0 };
			neuralNetwork.Execute();

			neuralNetwork.ExecuteBackPropagation();
		}
	}
}