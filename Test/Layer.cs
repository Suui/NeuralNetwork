

using System;
using System.Collections.Generic;

namespace Test
{
	public class Layer
	{
		public ConnectionDictionary Connections { get; }
		public ConnectionList ConnectionList { get; }

		public Layer(int leftPerceptrons, int rightPerceptrons)
		{
			Connections = ConnectionDictionaryBuilder.Build(leftPerceptrons, rightPerceptrons);
			ConnectionList = ConnectionListBuilder.Build(leftPerceptrons, rightPerceptrons);
		}

		public Weight WeightForConnection(Connection connection)
		{
			return Connections[connection];
		}

		public Connection Connection(int from, int to)
		{
			return ConnectionList[from, to];
		}
		public int Count()
		{
			return ConnectionList.Count();
		}
	}

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

	public class ConnectionList
	{
		Dictionary<Tuple<int, int>, Connection> Connections { get; } = new Dictionary<Tuple<int, int>, Connection>();

		public void Add(Connection connection)
		{
			Connections.Add(new Tuple<int, int>(connection.From, connection.To), connection);
		}

		public Connection this[int from, int to] => Connections[new Tuple<int, int>(@from, to)];

		public int Count()
		{
			return Connections.Count;
		}
	}
}