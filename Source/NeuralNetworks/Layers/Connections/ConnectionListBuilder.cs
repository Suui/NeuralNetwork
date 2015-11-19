namespace Source.NeuralNetworks.Layers.Connections
{
	public class ConnectionListBuilder
	{
		public static ConnectionList Build(int leftPerceptrons, int rightPerceptrons)
		{
			var connectionList = new ConnectionList();

			for (int i = 0; i < leftPerceptrons; i++)
			{
				for (int j = 0; j < rightPerceptrons; j++)
				{
					connectionList.Add(new Connection(i + 1, j + 1));
				}
			}

			return connectionList;
		}
	}
}