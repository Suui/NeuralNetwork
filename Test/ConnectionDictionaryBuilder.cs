

namespace Test
{
	public class ConnectionDictionaryBuilder
	{
		public static ConnectionDictionary Build(int leftPerceptrons, int rightPerceptrons)
		{
			var connectionDictionary = new ConnectionDictionary();

			for (int i = 0; i < leftPerceptrons; i++)
			{
				for (int j = 0; j < rightPerceptrons; j++)
				{
					connectionDictionary.Add(new Connection(i + 1, j + 1), new Weight());
				}
			}

			return connectionDictionary;
		}
	}
}