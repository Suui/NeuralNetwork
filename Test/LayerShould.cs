using System;
using System.Collections.Generic;
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