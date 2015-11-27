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
			for (var index = LayerDictionary.Count - 1; index >= 1; index--)
			{
				if (index == LayerDictionary.Count - 1)
				{
					for (var j = 1; j <= LayerDictionary[index].CountPerceptrons; j++)
					{
						for (var i = 1; i <= LayerDictionary[index+1].CountPerceptrons; i++)	// _lastLayer
						{
							DeltaDictionary[index+1].Delta(i).Value = LayerDictionary[index + 1].Perceptron(i).ExitValue()
									  * (1 - LayerDictionary[index + 1].Perceptron(i).ExitValue())
									  * GetErrorForExit(i);

							LayerDictionary[index].Connection(j, i).Weight -= _errorCoefficient * LayerDictionary[index].Perceptron(j).ExitValue() * DeltaDictionary[index+1].Delta(i).Value;
						}
					}
				}
			}
		}
	}
}