using Source.NeuralNetworks.NumberGenerators;


namespace Source.NeuralNetworks.Layers.Perceptrons
{
	public class PerceptronProperties
	{
		public PerceptronProperties(RandomGenerator thresholdGenerator)
		{
			IsEntryPerceptronList = false;
			ThresholdGenerator = thresholdGenerator;
		}

		public bool IsEntryPerceptronList { get; set; }
		public Layer PreviousLayer { get; set; }
		public RandomGenerator ThresholdGenerator { get; set; }
	}
}