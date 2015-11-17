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
					Connections.Add(new Connection(), new Weight());
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
	}
}