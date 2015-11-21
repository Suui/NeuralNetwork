using Source.NeuralNetworks.Thresholds;

namespace Source.NeuralNetworks.Layers.Perceptrons
{
	public class PerceptronProperties
	{
		public PerceptronProperties(ThresholdGenerator thresholdGenerator)
		{
			IsEntryPerceptronList = false;
			ThresholdGenerator = thresholdGenerator;
		}

		public bool IsEntryPerceptronList { get; set; }
		public Layer PreviousLayer { get; set; }
		public ThresholdGenerator ThresholdGenerator { get; set; }
	}
}