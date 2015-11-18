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
}