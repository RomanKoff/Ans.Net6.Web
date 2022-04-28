namespace Ans.Net6.Web
{

	public class NodeMapItem
	{

		public List<NodeMapItem> Masters { get; set; }
		public List<NodeMapItem> Items { get; set; }

		public string Name { get; set; }
		public string Title { get; set; }
		public string ExternalUrl { get; set; }
		public string InternalUrl { get; set; }
		public bool IsHidden { get; set; }
		public bool IsTargetBlank { get; set; }

		public bool IsExternal
			=> !string.IsNullOrEmpty(ExternalUrl);

		public bool IsInternal
			=> !string.IsNullOrEmpty(InternalUrl);

		public bool HasMasters
			=> Masters != null && Masters.Any();

		public bool HasItems
			=> Items != null && Items.Any();


		public NodeMapItem()
		{
		}

		public NodeMapItem(
			string serial)
			: this()
		{
			Parse(serial);
		}

		public NodeMapItem(
			string serial,
			params NodeMapItem[] items)
			: this(serial)
		{
			if (items.Any())
			{
				this.Items = new List<NodeMapItem>();
				foreach (var item1 in items)
					Items.Add(item1);
			}
		}


		public void Parse(
			string serial)
		{
			var a1 = serial.Split('|');
			switch (a1.Length)
			{
				case 2:
					_parse1(a1[0]);
					Title = a1[1];
					break;
				default:
					Title = a1[0];
					break;
			}
		}


		// privates

		private void _parse1(
			string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				switch (value[0])
				{
					case '^':
						IsTargetBlank = true;
						ExternalUrl = value[1..];
						break;
					case '~':
						InternalUrl = value[1..];
						break;
				}
			}
			Name = value;
		}

	}

}
