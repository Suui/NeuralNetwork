namespace Source.Layers
{
	public class LayerListBuilder
	{
		private readonly LayerList _layerList;
		private int _index;
		private int _leftPerceptrons;

		public LayerListBuilder()
		{
			_layerList = new LayerList();
		}

		public LayerListBuilder Build()
		{
			return this;
		}

		public LayerListBuilder WithLayer(int index)
		{
			_index = index;
			return this;
		}

		public LayerListBuilder From(int leftPerceptrons)
		{
			_leftPerceptrons = leftPerceptrons;
			return this;
		}

		public LayerListBuilder To(int rightPerceptrons)
		{
			_layerList.LayerDictionary.Add(_index, new Layer(_index, _leftPerceptrons, rightPerceptrons));
			return this;
		}

		public LayerList Get()
		{
			return _layerList;
		}
	}
}