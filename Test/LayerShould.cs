using System;
using FluentAssertions;
using NUnit.Framework;

namespace Test
{
	[TestFixture]
	public class LayerShould
	{
		[Test]
		public void have_8_connections_when_built_with_2_and_4()
		{
			var layer = new Layer(2, 4);

			layer.GetConnections().Count.Should().Be(8);
		}

		[Test]
		public void have_the_correct_indexes()
		{
			var layer = new Layer(2, 4);

			layer.GetConnections().ContainsKey(new Connection(2, 4)).Should().BeTrue();
		}
	}

	public class Weight
	{
	}

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