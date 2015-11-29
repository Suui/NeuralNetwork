using System.IO;
using Source.NeuralNetworks;


namespace Source.ByteFileReaders
{
	public class ByteFileReader
	{
		private readonly FileStream _fileStream;

		public ByteFileReader(string filePath, long offset)
		{
			_fileStream = new FileStream(filePath, FileMode.Open);
			_fileStream.Seek(offset, SeekOrigin.Begin);
		}

		public ValueList<double> Next()
		{
			return new ValueList<double> { _fileStream.ReadByte() };
		}

		public ValueList<double> Next(int numberOfBytes)
		{
			var byteValues = new ValueList<double>();

			for (var i = 0; i < numberOfBytes; i++)
				byteValues.Add(_fileStream.ReadByte());

			return byteValues;
		}

		public void Close()
		{
			_fileStream.Close();
		}
	}
}