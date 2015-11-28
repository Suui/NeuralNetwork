using Source.ByteFileReaders;
using Source.NeuralNetworks;


namespace Source
{
	class Program
	{
		static void Main(string[] args)
		{
			var neuralNetwork = NeuralNetworkFactory.NeuralNetworkForPracticeFour();

			var labelsReader = new LabelsReader(@"D:\Projects\Programming\C#\NeuralNetwork\DataMNIST\train_labels");
			var imagesReader = new ImagesReader(@"D:\Projects\Programming\C#\NeuralNetwork\DataMNIST\train_images");
			neuralNetwork.ExpectedExitValues = labelsReader.Next();
			neuralNetwork.EntryValues = imagesReader.Next(784);
		}
	}
}
