using System;

namespace Source.NeuralNetworks.Layers.Perceptrons
{
	public class ThresholdRandomizer
	{
		public static Random Random = new Random();

		public virtual double GetThreshold()
		{
			return Random.Next(int.MaxValue) - int.MaxValue/2;
		}
	}
}