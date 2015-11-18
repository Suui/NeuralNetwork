namespace Source.Layers
{
	public class LayerDictionaryBuilder
	{
		private readonly LayerDictionary _layerDictionary;
		private int _index;
		private int _leftPerceptrons;

		public LayerDictionaryBuilder()
		{
			_layerDictionary = new LayerDictionary();
		}

		public LayerDictionaryBuilder Build()
		{
			return this;
		}

		public LayerDictionaryBuilder WithLayer(int index)
		{
			_index = index;
			return this;
		}

		public LayerDictionaryBuilder From(int leftPerceptrons)
		{
			_leftPerceptrons = leftPerceptrons;
			return this;
		}

		public LayerDictionaryBuilder To(int rightPerceptrons)
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