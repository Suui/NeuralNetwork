using System.IO;
using Source.NeuralNetworks;


namespace Source.ByteFileReaders
{
	public class ImagesReader
	{
		private readonly FileStream _fileStream;
		private const int ImagesOffset = 16;

		public ImagesReader(string filePath)
		{
			_fileStream = new FileStream(filePath, FileMode.Open);
			_fileStream.Seek(ImagesOffset, SeekOrigin.Begin);
		}

		public ValueList<double> Next(int numberOfBytes)
		{
			var byteValues = new ValueList<double>();

			for (var i = 0; i < numberOfBytes; i++)
				byteValues.Add(_fileStream.ReadByte());

			return byteValues;
		}
	}
}