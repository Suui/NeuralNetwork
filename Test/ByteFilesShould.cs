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
		private byte[] _bytes;

		[SetUp]
		public void Initialize()
		{
			_bytes = new byte[4];
			_trainLabels = @"D:\Projects\Programming\C#\NeuralNetwork\DataMNIST\train_labels";
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
		}
	}
}