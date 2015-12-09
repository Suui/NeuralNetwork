using System;
using Source.ByteFileReaders;
using Source.NeuralNetworks;


namespace Source.Applications
{
	public class PracticeFourApplication : CustomApplication
	{
		public override void Execute()
		{
			var neuralNetwork = NeuralNetworkFactory.NeuralNetworkForPracticeFour();
			var errorCalculator = new ErrorCalculator();

			var labelsReader = new ByteFileReader(@"D:\Projects\Programming\C#\NeuralNetwork\DataMNIST\train_labels", 8);
			var imagesReader = new ByteFileReader(@"D:\Projects\Programming\C#\NeuralNetwork\DataMNIST\train_images", 16);
			for (int i = 0; i < 60000; i++)
			{
				neuralNetwork.ExpectedExitValues = labelsReader.Next();
				neuralNetwork.EntryValues = imagesReader.Next(784);

				neuralNetwork.Execute();
				neuralNetwork.ExecuteBackPropagation();

				errorCalculator.AddResult(neuralNetwork.ExpectedExitValues[1], neuralNetwork.ExitValues[1]);
				Console.WriteLine("MSE for iteration " + i + " = " + errorCalculator.GetMSE() + ",  Success Percentage = " + errorCalculator.GetSuccessPercentage());
			}
		}
	}
}