using System.IO;
using Source.NeuralNetworks;


namespace Source.ByteFileReaders
{
	public class LabelsReader
	{
		private readonly FileStream _fileStream;
		private const int LabelsOffset = 8;

		public LabelsReader(string filePath)
		{
			_fileStream = new FileStream(filePath, FileMode.Open);
			_fileStream.Seek(LabelsOffset, SeekOrigin.Begin);
		}

		public ValueList<double> Next()
		{
			return new ValueList<double> { _fileStream.ReadByte() };
		}

		public void Close()
		{
			_fileStream.Close();
		}
	}
}