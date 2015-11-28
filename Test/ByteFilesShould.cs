using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;


namespace Test
{
	[TestFixture]
	public class ByteFilesShould
	{
		private string _trainLabels;
		private string _trainImages;
		private byte[] _bytes;

		[SetUp]
		public void Initialize()
		{
			_bytes = new byte[4];

			const string rootDirectory = @"D:\Projects\Programming\C#\NeuralNetwork\DataMNIST\";
			_trainLabels = rootDirectory + "train_labels";
			_trainImages = rootDirectory + "train_images";
		}

		[Test]
		public void have_the_correct_magic_number_for_the_train_labels()
		{
			var fileStream = new FileStream(_trainLabels, FileMode.Open);

			fileStream.Read(_bytes, 0, 4);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(_bytes);

			var magicNumber = BitConverter.ToInt32(_bytes, 0);
			magicNumber.Should().Be(2049);

			fileStream.Close();
		}

		[Test]
		public void have_the_correct_number_of_items_for_the_train_labels()
		{
			var fileStream = new FileStream(_trainLabels, FileMode.Open);

			fileStream.Seek(4, SeekOrigin.Begin);
			fileStream.Read(_bytes, 0, 4);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(_bytes);

			var numberOfItem = BitConverter.ToInt32(_bytes, 0);
			numberOfItem.Should().Be(60000);

			fileStream.Close();
		}

		[Test]
		public void have_the_correct_magic_number_for_the_train_images()
		{
			var fileStream = new FileStream(_trainImages, FileMode.Open);

			fileStream.Read(_bytes, 0, 4);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(_bytes);

			var magicNumber = BitConverter.ToInt32(_bytes, 0);
			magicNumber.Should().Be(2051);

			fileStream.Close();
		}

		[Test]
		public void have_the_correct_number_of_images_for_the_train_images()
		{
			var fileStream = new FileStream(_trainImages, FileMode.Open);

			fileStream.Seek(4, SeekOrigin.Begin);
			fileStream.Read(_bytes, 0, 4);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(_bytes);

			var numberOfImages = BitConverter.ToInt32(_bytes, 0);
			numberOfImages.Should().Be(60000);

			fileStream.Close();
		}
	}
}