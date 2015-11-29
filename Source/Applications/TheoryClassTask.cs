using System.IO;


namespace Source.Applications
{
	public class TheoryClassTask : CustomApplication
	{
		public override void Execute()
		{
			const string fileName = "inputs";
			CreateByteFile(fileName);
		}

		private void CreateByteFile(string fileName)
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
		}
	}
}