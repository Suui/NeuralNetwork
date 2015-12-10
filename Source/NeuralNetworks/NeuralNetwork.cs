using System.Collections.Generic;
using Source.AcceptanceMatchers;
using Source.NeuralNetworks.Deltas;
using Source.NeuralNetworks.Layers;
using Source.NeuralNetworks.Layers.Perceptrons;


namespace Source.NeuralNetworks
{
	public class NeuralNetwork
	{
		private LayerDictionary LayerDictionary { get; }
		private DeltaDictionary DeltaDictionary { get; }
        public ValueList<double> EntryValues { get; set; }
		public ValueList<double> ExitValues { get; set; }
		public ValueList<double> ExpectedExitValues { get; set; }
		private readonly AcceptanceMatcher _acceptanceMatcher;
		private readonly double _errorCoefficient;

		public NeuralNetwork(LayerDictionary layers, AcceptanceMatcher acceptanceMatcher)
		{
			LayerDictionary = layers;
			DeltaDictionary = DeltaDictionaryBuilder.Build(LayerDictionary);
			EntryValues = new ValueList<double>();
			ExitValues = new ValueList<double>();
			_acceptanceMatcher = acceptanceMatcher;
			_errorCoefficient = 0.2;
		}

		public void Execute()
		{
			if (EntryValues.Count != 0)
				LayerDictionary.SetEntryPerceptrons(EntryValues);

			ExitValues = LayerDictionary.GetLastLayerExitValues();
		}

		public void ExecuteBackPropagation()
		{
			SetUp();
			Apply();
		}

		private void SetUp()
		{
			for (var index = LayerDictionary.Count - 1; index >= 1; index--)
			{
				CalculateDeltas(index + 1);
				CalculateDerivativeErrors(index);
			}
		}

		private void Apply()
		{
			for (var i = LayerDictionary.Count; i >= 1; i--)
			{
				ApplyToPerceptrons(i);
				ApplyToConnections(i);
			}
		}

		private void ApplyToPerceptrons(int i)
		{
			foreach (Perceptron perceptron in LayerDictionary[i].Perceptrons)
			{
				var innerPerceptron = perceptron as InnerPerceptron;
				innerPerceptron?.ApplyDerivativeError();
			}
		}

		private void ApplyToConnections(int i)
		{
			if (i == LayerDictionary.Count) return;

			for (var j = 1; j <= LayerDictionary[i].CountPerceptrons; j++)
			{
				for (var k = 1; k <= LayerDictionary[i + 1].CountPerceptrons; k++)
				{
					LayerDictionary[i].Connection(j, k).ApplyDerivativeError();
				}
			}
		}

		private void CalculateDerivativeErrors(int index)
		{
			CalculateDerivativeErrorsForThresholds(index+1);
			CalculateDerivativeErrorsForWeights(index);
		}

		private void CalculateDerivativeErrorsForThresholds(int index)
		{
			for (var i = 1; i <= LayerDictionary[index].CountPerceptrons; i++)
			{
				LayerDictionary[index].Perceptron(i).DerivativeError = _errorCoefficient * DeltaDictionary[index].Delta(i).Value;
			}
		}

		private void CalculateDerivativeErrorsForWeights(int index)
		{
			for (var j = 1; j <= LayerDictionary[index].CountPerceptrons; j++)
			{
				for (var i = 1; i <= LayerDictionary[index + 1].CountPerceptrons; i++)
				{
					LayerDictionary[index].Connection(j, i).DerivativeError = _errorCoefficient
																			* LayerDictionary[index].Perceptron(j).ExitValue()
																			* DeltaDictionary[index + 1].Delta(i).Value;
				}
			}
		}

		private void CalculateDeltas(int index)
		{
			if (index == LayerDictionary.Count)
				CalculateLastLayerDeltas(index);
			else
				CalculateHiddenLayerDeltas(index);
		}

		private void CalculateLastLayerDeltas(int index)
		{
			for (var i = 1; i <= LayerDictionary[index].CountPerceptrons; i++)
				DeltaDictionary[index].Delta(i).Value = ExitValueDerivate(index, i) * GetErrorForExit(i);
		}

		private void CalculateHiddenLayerDeltas(int index)
		{
			for (var i = 1; i <= LayerDictionary[index].CountPerceptrons; i++)
				DeltaDictionary[index].Delta(i).Value = ExitValueDerivate(index, i) * Summation(index, i);
		}

		private double ExitValueDerivate(int index, int i)
		{
			return LayerDictionary[index].Perceptron(i).ExitValue()
				 * (1 - LayerDictionary[index].Perceptron(i).ExitValue());
		}

		public double GetErrorForExit(int index)
		{
			return _acceptanceMatcher
					.ForExpectedValue(ExpectedExitValues[index])
					.IsValue(ExitValues[index]).Accepted() ? 0.0
														   : -(ExpectedExitValues[index] - ExitValues[index]);
		}

		private double Summation(int index, int j)
		{
			var result = 0.0;

			for (var i = 1; i <= LayerDictionary[index + 1].CountPerceptrons; i++)
				result += LayerDictionary[index].Connection(j, i).Weight * DeltaDictionary[index + 1].Delta(i).Value;

			return result;
		}

		public List<double> GetWeightsForLayer(int index)
		{
			if (index == LayerDictionary.Count) return new List<double>();

			var result = new List<double>();

			for (var j = 1; j <= LayerDictionary[index].CountPerceptrons; j++)
			{
				for (var k = 1; k <= LayerDictionary[index + 1].CountPerceptrons; k++)
				{
					result.Add(LayerDictionary[index].Connection(j, k).Weight);
				}
			}

			return result;
		}

		public List<double> GetThresholdsForLayer(int index)
		{
			var result = new List<double>();

			foreach (Perceptron perceptron in LayerDictionary[index].Perceptrons)
			{
				var innerPerceptron = perceptron as InnerPerceptron;
				if (innerPerceptron != null) result.Add(innerPerceptron.Threshold);
			}

			return result;
		}

		public void SetWeightsForLayer(int index, ValueList<double> values)
		{
			var count = 1;
			for (var j = 1; j <= LayerDictionary[index].CountPerceptrons; j++)
			{
				for (var k = 1; k <= LayerDictionary[index + 1].CountPerceptrons; k++)
				{
					LayerDictionary[index].Connection(j, k).Weight = values[count];
					count += 1;
				}
			}
		}

		public void SetThresholdsForLayer(int index, ValueList<double> values)
		{
			for (var i = 1; i <= LayerDictionary[index].CountPerceptrons; i++)
			{
				var innerPerceptron = LayerDictionary[index].Perceptron(i) as InnerPerceptron;
				if (innerPerceptron != null) innerPerceptron.Threshold = values[i];
			}
		}
	}
}