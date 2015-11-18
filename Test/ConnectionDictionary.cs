using System.Collections.Generic;


namespace Test
{
	public class ConnectionDictionary
	{
		public Dictionary<Connection, Weight> Connections { get; set; }

		public ConnectionDictionary()
		{
			Connections = new Dictionary<Connection, Weight>();
		}

		public void Add(Connection connection, Weight weight)
		{
			Connections.Add(connection, weight);
		}

		public int Count()
		{
			return Connections.Count;
		}

		public bool ContainsKey(Connection connection)
		{
			return Connections.ContainsKey(connection);
		}
	}
}