using Source.NeuralNetworks.Deltas;
using Source.NeuralNetworks.Layers;


namespace Source.NeuralNetworks
{
	public class NeuralNetwork
	{
		private LayerDictionary LayerDictionary { get; }
		private DeltaDictionary DeltaDictionary { get; }
        public ValueList<double> EntryValues { get; set; }
		public ValueList<double> ExitValues { get; set; }
		public ValueList<double> ExpectedExitValues { get; set; }
		private readonly double _errorCoefficient;

		public NeuralNetwork(LayerDictionary layers)
		{
			LayerDictionary = layers;
			DeltaDictionary = DeltaDictionaryBuilder.Build(LayerDictionary);
			EntryValues = new ValueList<double>();
			ExitValues = new ValueList<double>();
			_errorCoefficient = 0.1;
		}

		public void Execute()
		{
			if (EntryValues.Count != 0)
				LayerDictionary.SetEntryPerceptrons(EntryValues);

			ExitValues = LayerDictionary.GetLastLayerExitValues();
		}

		public void ExecuteBackPropagation()
		{
			for (var index = LayerDictionary.Count - 1; index >= 1; index--)
			{
				CalculateDeltas(index + 1);
				CalculateDerivativeErrors(index);
			}
		}

		private void CalculateDerivativeErrors(int index)
		{
			for (var j = 1; j <= LayerDictionary[index].CountPerceptrons; j++)
			{
				for (var i = 1; i <= LayerDictionary[index + 1].CountPerceptrons; i++)
				{
					LayerDictionary[index].Perceptron(i).DerivativeError = _errorCoefficient
					                                                       * DeltaDictionary[index + 1].Delta(i).Value;

					LayerDictionary[index].Connection(j, i).DerivativeError = LayerDictionary[index].Perceptron(j).ExitValue()
																			* LayerDictionary[index].Perceptron(i).DerivativeError;
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
			return -(ExpectedExitValues[index] - ExitValues[index]);
		}

		private double Summation(int index, int j)
		{
			var result = 0.0;

			for (var i = 1; i <= LayerDictionary[index + 1].CountPerceptrons; i++)
				result += LayerDictionary[index].Connection(j, i).Weight * DeltaDictionary[index + 1].Delta(i).Value;

			return result;
		}
	}
}