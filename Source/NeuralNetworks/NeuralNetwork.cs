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

		public double GetErrorForExit(int index)
		{
			return -(ExpectedExitValues[index] - ExitValues[index]);
		}

		public void ExecuteBackPropagation()
		{
			CalculateLastLayerDeltas();

			for (var index = LayerDictionary.Count - 1; index >= 1; index--)
			{
				if (index == LayerDictionary.Count - 1)
				{
					for (var j = 1; j <= LayerDictionary[index].CountPerceptrons; j++)
					{
						for (var i = 1; i <= LayerDictionary[index+1].CountPerceptrons; i++)	// _lastLayer
						{
							LayerDictionary[index].Connection(j, i).Weight -= _errorCoefficient * LayerDictionary[index].Perceptron(j).ExitValue() * DeltaDictionary[index+1].Delta(i).Value;
						}
					}
				}
				if (index == LayerDictionary.Count - 2)
				{
					for (var h = 1; h <= LayerDictionary[index].CountPerceptrons; h++)
					{
						for (var j = 1; j <= LayerDictionary[index+1].CountPerceptrons; j++)
						{
							var summation = 0.0;
							for (var i = 1; i <= LayerDictionary[index+2].CountPerceptrons; i++)
							{
								summation += LayerDictionary[index+1].Connection(j, i).Weight * DeltaDictionary[index+2].Delta(i).Value;
							}

							LayerDictionary[index].Connection(h, j).Weight -= _errorCoefficient
																			* LayerDictionary[index].Perceptron(h).ExitValue()
																			* LayerDictionary[index+1].Perceptron(j).ExitValue()
																			* (1 - LayerDictionary[index + 1].Perceptron(j).ExitValue())
																			* summation;
						}
					}
				}
			}
		}

		private void CalculateLastLayerDeltas()
		{
			var lastLayerIndex = LayerDictionary.Count;
			for (var i = 1; i <= LayerDictionary[lastLayerIndex].CountPerceptrons; i++)
			{
				DeltaDictionary[lastLayerIndex].Delta(i).Value = LayerDictionary[lastLayerIndex].Perceptron(i).ExitValue()
													  * (1 - LayerDictionary[lastLayerIndex].Perceptron(i).ExitValue())
													  * GetErrorForExit(i);
			}
		}
	}
}