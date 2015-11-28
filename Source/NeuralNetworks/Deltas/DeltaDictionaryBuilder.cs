using Source.NeuralNetworks.Layers;


namespace Source.NeuralNetworks.Deltas
{
	public class DeltaDictionaryBuilder
	{
		public static DeltaDictionary Build(LayerDictionary layers)
		{
			var deltaDictionary = new DeltaDictionary();

			for (var i = 2; i <= layers.Count; i++)
				deltaDictionary.Add(i, new DeltaList(layers[i].CountPerceptrons));

			return deltaDictionary;
		}
	}
}