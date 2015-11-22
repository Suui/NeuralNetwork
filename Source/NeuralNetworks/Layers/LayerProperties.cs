using Source.NeuralNetworks.Layers.Connections;
using Source.NeuralNetworks.Layers.Perceptrons;


namespace Source.NeuralNetworks.Layers
{
	public class LayerProperties
	{
		public int LeftPerceptrons { get; set; }
		public int RightPerceptrons { get; set; }
		public ConnectionProperties ConnectionProperties { get; set; }
		public PerceptronProperties PerceptronProperties { get; set; }
	}
}