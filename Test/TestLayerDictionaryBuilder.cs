using Source.Layers;


namespace Test
{
	public class TestLayerDictionaryBuilder
	{
		private readonly LayerDictionary _layerDictionary;
		private int _index;
		private int _leftPerceptrons;

		public TestLayerDictionaryBuilder()
		{
			_layerDictionary = new LayerDictionary();
		}

		public TestLayerDictionaryBuilder Build()
		{
			return this;
		}

		public TestLayerDictionaryBuilder WithLayer(int index)
		{
			_index = index;
			return this;
		}

		public TestLayerDictionaryBuilder From(int leftPerceptrons)
		{
			_leftPerceptrons = leftPerceptrons;
			return this;
		}

		public TestLayerDictionaryBuilder To(int rightPerceptrons)
		{
			_layerDictionary.Add(_index,
								 _layerDictionary.HasLayer(_index - 1) ? new Layer(_leftPerceptrons, rightPerceptrons, _layerDictionary[_index - 1])
																	   : new Layer(_leftPerceptrons, rightPerceptrons));
			return this;
		}

		public LayerDictionary Get()
		{
			return _layerDictionary;
		}
	}
}