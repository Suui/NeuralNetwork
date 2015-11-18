using System;
using System.Collections.Generic;


namespace Test
{
	public class Layer
	{
		public ConnectionList ConnectionList { get; }

		public Layer(int leftPerceptrons, int rightPerceptrons)
		{
			ConnectionList = ConnectionListBuilder.Build(leftPerceptrons, rightPerceptrons);
		}

		public Connection Connection(int from, int to)
		{
			return ConnectionList[from, to];
		}

		public bool HasConnection(int from, int to)
		{
			return ConnectionList.ContainsKey(from, to);
		}

		public int Count()
		{
			return ConnectionList.Count();
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

		public bool ContainsKey(int from, int to)
		{
			return Connections.ContainsKey(new Tuple<int, int>(from, to));
		}

		public int Count()
		{
			return Connections.Count;
		}
	}
}