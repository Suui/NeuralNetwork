using Source.NeuralNetworks.Thresholds;

namespace Source.NeuralNetworks.Layers.Perceptrons
{
	public struct PerceptronProperties
	{
		public bool IsEntryPerceptronList { get; set; }
		public Layer PreviousLayer { get; set; }
		public ThresholdGenerator ThresholdGenerator { get; set; }
	}
}