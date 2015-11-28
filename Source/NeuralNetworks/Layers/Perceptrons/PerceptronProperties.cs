using Source.Formulas;
using Source.NumberGenerators;


namespace Source.NeuralNetworks.Layers.Perceptrons
{
	public class PerceptronProperties
	{
		public bool IsEntryPerceptronList { get; set; }
		public Layer PreviousLayer { get; set; }
		public NumberGenerator ThresholdGenerator { get; set; }
		public Formula Formula { get; set; }

		public PerceptronProperties(NumberGenerator thresholdGenerator, Formula formula = null)
		{
			IsEntryPerceptronList = false;
			ThresholdGenerator = thresholdGenerator;
			Formula = formula ?? new Sigmoid();
		}
	}
}