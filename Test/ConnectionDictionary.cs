using System.Collections.Generic;


namespace Test
{
	public class ConnectionDictionary
	{
		private Dictionary<Connection, Weight> Connections { get; }

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

		public Weight this[Connection connection]
		{
			get { return Connections[connection]; }
			set { Connections[connection]= value; }
		}
	}
}