using Source.NumberGenerators;

namespace Source.NeuralNetworks.Layers.Perceptrons
{
	public class PerceptronProperties
	{
		public bool IsEntryPerceptronList { get; set; }
		public Layer PreviousLayer { get; set; }
		public NumberGenerator ThresholdGenerator { get; set; }

		public PerceptronProperties(NumberGenerator thresholdGenerator)
		{
			IsEntryPerceptronList = false;
			ThresholdGenerator = thresholdGenerator;
		}
	}
}