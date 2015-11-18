namespace Test
{
	public class Connection
	{
		public int From { get; set; }
		public int To { get; set; }

		public Connection(int from, int to)
		{
			From = from;
			To = to;
		}

		protected bool Equals(Connection other)
		{
			return From == other.From && To == other.To;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Connection) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (From*397) ^ To;
			}
		}
	}
}