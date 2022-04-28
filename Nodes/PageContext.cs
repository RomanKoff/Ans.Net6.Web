namespace Ans.Net6.Web.Nodes
{

	public interface IPageContext
		: I_CommonContext
	{
		NodeMapItem NodeMapItem { get; set; }

		string FullTitle { get; set; }
		string MetaDescription { get; set; }
		string MetaKeywords { get; set; }
		string BreadcrumbCssClass { get; set; }
		bool OffContainer { get; set; }
		bool HideBrowserTitle { get; set; }
		bool HidePageTitle { get; set; }

		bool AllowBrowserTitle { get; }
		bool AllowPageTitle { get; }
	}



	public class PageContext
		: _CommonContext_Base,
		IPageContext
	{
		private string _fullTitle;

		public NodeMapItem NodeMapItem { get; set; }
		public string FullTitle { get => _fullTitle ?? Title; set => _fullTitle = value; }
		public string MetaDescription { get; set; }
		public string MetaKeywords { get; set; }
		public string BreadcrumbCssClass { get; set; }
		public bool OffContainer { get; set; }
		public bool HideBrowserTitle { get; set; }
		public bool HidePageTitle { get; set; }

		public bool AllowBrowserTitle
			=> !HideBrowserTitle && !string.IsNullOrEmpty(Title);

		public bool AllowPageTitle
			=> !HidePageTitle && !string.IsNullOrEmpty(Title);

		public PageContext()
		{
			System.Diagnostics.Debug.WriteLine("--- new PageContext()");
		}
	}

}