using System;
using System.IO;
using Source.ByteFileReaders;
using Source.NeuralNetworks;
using Source.NeuralNetworks.Layers.Connections;
using Source.NeuralNetworks.Layers.Perceptrons;
using Source.NumberGenerators;


namespace Source.Applications
{
	public class TheoryClassTask : CustomApplication
	{
		public override void Execute()
		{
			CreateInputs("inputs");
			CreateExpectedOutputs("expected_outputs");

			var neuralNetwork = new NeuralNetworkBuilder(new ConnectionProperties(new DelimitedRandom(-1, 1)), 
								new PerceptronProperties(new DelimitedRandom(-1, 1)))
								.WithLayer(1).From(9).To(9)
								.WithLayer(2).From(9).To(6)
								.WithLayer(3).From(6).To(3)
								.WithLayer(4).From(3).To(1)
								.Build();

			var errorCalculator = new ErrorCalculator();
			var inputReader = new ByteFileReader("inputs", 0);
			var expectedOutputReader = new ByteFileReader("expected_outputs", 0);

			for (var i = 0; i < 54*1000; i++)
			{
				neuralNetwork.EntryValues = inputReader.Next(9);
				neuralNetwork.ExpectedExitValues = expectedOutputReader.Next();

				neuralNetwork.Execute();
				neuralNetwork.ExecuteBackPropagation();

				errorCalculator.AddResult(neuralNetwork.ExpectedExitValues[1], neuralNetwork.ExitValues[1]);
				Console.WriteLine("MSE for iteration " + i + " = " + errorCalculator.GetMSE());

				if (i % 54 == 0)
				{
					inputReader.Close();
					expectedOutputReader.Close();
					inputReader = new ByteFileReader("inputs", 0);
					expectedOutputReader = new ByteFileReader("expected_outputs", 0);
				}
			}
		}

		private void CreateExpectedOutputs(string fileName)
		{
			if (File.Exists(fileName)) return;

			var fileStream = new FileStream(fileName, FileMode.Create);
			fileStream.WriteByte(1);
			fileStream.WriteByte(1);
			fileStream.WriteByte(1);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
		}

		private void CreateInputs(string fileName)
		{
			if (File.Exists(fileName)) return;

			var fileStream = new FileStream(fileName, FileMode.Create);
			fileStream.WriteByte(1);
			fileStream.WriteByte(1);
			fileStream.WriteByte(1);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);

			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(1);
			fileStream.WriteByte(1);
			fileStream.WriteByte(1);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);

			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(1);
			fileStream.WriteByte(1);
			fileStream.WriteByte(1);

			fileStream.WriteByte(1);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(1);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(1);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);

			fileStream.WriteByte(0);
			fileStream.WriteByte(1);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(1);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(1);
			fileStream.WriteByte(0);

			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(1);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(1);
			fileStream.WriteByte(0);
			fileStream.WriteByte(0);
			fileStream.WriteByte(1);

			fileStream.Close();
		}
	}
}