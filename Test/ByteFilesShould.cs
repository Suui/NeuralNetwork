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
		private string _testLabels;
		private string _testImages;

		[SetUp]
		public void Initialize()
		{
			_bytes = new byte[4];

			const string rootDirectory = @"D:\Projects\Programming\C#\NeuralNetwork\DataMNIST\";
			_trainLabels = rootDirectory + "train_labels";
			_trainImages = rootDirectory + "train_images";
			_testLabels = rootDirectory + "test_labels";
			_testImages = rootDirectory + "test_images";
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

		[Test]
		public void have_the_correct_number_of_rows_for_the_images_in_the_train_images()
		{
			var fileStream = new FileStream(_trainImages, FileMode.Open);

			fileStream.Seek(8, SeekOrigin.Begin);
			fileStream.Read(_bytes, 0, 4);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(_bytes);

			var rowsInImage = BitConverter.ToInt32(_bytes, 0);
			rowsInImage.Should().Be(28);

			fileStream.Close();
		}

		[Test]
		public void have_the_correct_number_of_columns_for_the_images_in_the_train_images()
		{
			var fileStream = new FileStream(_trainImages, FileMode.Open);

			fileStream.Seek(12, SeekOrigin.Begin);
			fileStream.Read(_bytes, 0, 4);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(_bytes);

			var columnsInImage = BitConverter.ToInt32(_bytes, 0);
			columnsInImage.Should().Be(28);

			fileStream.Close();
		}

		[Test]
		public void have_the_correct_magic_number_for_the_test_labels()
		{
			var fileStream = new FileStream(_testLabels, FileMode.Open);

			fileStream.Read(_bytes, 0, 4);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(_bytes);

			var magicNumber = BitConverter.ToInt32(_bytes, 0);
			magicNumber.Should().Be(2049);

			fileStream.Close();
		}

		[Test]
		public void have_the_correct_number_of_items_for_the_test_labels()
		{
			var fileStream = new FileStream(_testLabels, FileMode.Open);

			fileStream.Seek(4, SeekOrigin.Begin);
			fileStream.Read(_bytes, 0, 4);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(_bytes);

			var numberOfItem = BitConverter.ToInt32(_bytes, 0);
			numberOfItem.Should().Be(10000);

			fileStream.Close();
		}

		[Test]
		public void have_the_correct_magic_number_for_the_test_images()
		{
			var fileStream = new FileStream(_testImages, FileMode.Open);

			fileStream.Read(_bytes, 0, 4);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(_bytes);

			var magicNumber = BitConverter.ToInt32(_bytes, 0);
			magicNumber.Should().Be(2051);

			fileStream.Close();
		}
	}
}