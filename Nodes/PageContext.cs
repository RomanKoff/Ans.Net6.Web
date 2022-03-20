namespace Ans.Net6.Web.Nodes
{

	public interface IPageContext
		: I_Context_Base
	{
		string MetaDescription { get; set; }
		string MetaKeywords { get; set; }
		bool OffContainer { get; set; }
		string BreadcrumbCssClass { get; set; }

		void InsertToBreadcrumb(string title);
		void InsertToBreadcrumb();
	}


	public class PageContext
		: _Context_Base,
		IPageContext
	{
		public string MetaDescription { get; set; }
		public string MetaKeywords { get; set; }
		public bool OffContainer { get; set; }
		public string BreadcrumbCssClass { get; set; }

		public void InsertToBreadcrumb(
			string title)
		{
			InsertToBreadcrumb(new NavigationItem { Href = "#", InnerHtml = title });
		}

		public void InsertToBreadcrumb()
		{
			InsertToBreadcrumb(TitleShort);
		}
	}

}