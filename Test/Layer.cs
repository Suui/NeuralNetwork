

namespace Test
{
	public class Layer
	{
		private ConnectionDictionary Connections { get; }

		public Layer(int leftPerceptrons, int rightPerceptrons)
		{
			Connections = new ConnectionDictionary();
			for (int i = 0; i < leftPerceptrons; i++)
			{
				for (int j = 0; j < rightPerceptrons; j++)
				{
					Connections.Add(new Connection(i+1, j+1), new Weight());
				}
			}
		}

		public ConnectionDictionary GetConnections()
		{
			return Connections;
		}
	}
}