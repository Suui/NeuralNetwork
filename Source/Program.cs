﻿using System;
using Source.ByteFileReaders;
using Source.NeuralNetworks;


namespace Source
{
	class Program
	{
		static void Main(string[] args)
		{
			var neuralNetwork = NeuralNetworkFactory.NeuralNetworkForPracticeFour();

			var labelsReader = new ByteFileReader(@"D:\Projects\Programming\C#\NeuralNetwork\DataMNIST\train_labels", 8);
			var imagesReader = new ByteFileReader(@"D:\Projects\Programming\C#\NeuralNetwork\DataMNIST\train_images", 16);
			for (int i = 0; i < 60000; i++)
			{
				neuralNetwork.ExpectedExitValues = labelsReader.Next();
				neuralNetwork.EntryValues = imagesReader.Next(784);

				neuralNetwork.Execute();
				neuralNetwork.ExecuteBackPropagation();
				Console.WriteLine("i = " + i);
			}
		}
	}
}
