using System.Collections.Generic;

namespace Test
{
	public class Layer
	{
		private Dictionary<Connection, Weight> Connections { get; }

		public Layer(int leftPerceptrons, int rightPerceptrons)
		{
			Connections = new Dictionary<Connection, Weight>();
			for (int i = 0; i < leftPerceptrons; i++)
			{
				for (int j = 0; j < rightPerceptrons; j++)
				{
					Connections.Add(new Connection(i+1, j+1), new Weight());
				}
			}
		}

		public Dictionary<Connection, Weight> GetConnections()
		{
			return Connections;
		}
	}
}