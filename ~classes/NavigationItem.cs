namespace Ans.Net6.Web
{

	public class NavigationItem
	{
		public List<NavigationItem> Items { get; set; }

		public string Id { get; set; }
		public string Class { get; set; }
		public string Href { get; set; }
		public string InnerHtml { get; set; }
		public bool IsActive { get; set; }
		public bool IsSubActive { get; set; }
		public bool IsTargetBlank { get; set; }
		public bool IsHidden { get; set; }
		public bool IsDisabled { get; set; }

		public bool HasItems
			=> Items != null && Items.Any();
	}

}
