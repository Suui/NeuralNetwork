using System;
using System.Collections.Generic;


namespace Source.NeuralNetworks.Layers.Connections
{
	public class ConnectionList
	{
		private Dictionary<Tuple<int, int>, Connection> Connections { get; } = new Dictionary<Tuple<int, int>, Connection>();
		public int Count => Connections.Count;

		public void Add(Connection connection)
		{
			Connections.Add(new Tuple<int, int>(connection.From, connection.To), connection);
		}

		public bool ContainsKey(int from, int to)
		{
			return Connections.ContainsKey(new Tuple<int, int>(from, to));
		}

		public Connection this[int from, int to] => Connections[new Tuple<int, int>(from, to)];
	}
}