namespace Ans.Net6.Web.Nodes
{

	public interface ISiteContext
		: I_Context_Base
	{
		string HomeUrl { get; set; }
		string HeaderCssClass { get; set; }
		string FooterCssClass { get; set; }

		void InsertToBreadcrumb();
	}


	public class SiteContext
		: _Context_Base,
		ISiteContext
	{
		public string HomeUrl { get; set; }

		public string HeaderCssClass
		{
			get => _headerCssClass ?? "default";
			set => _headerCssClass = value;
		}
		private string _headerCssClass;

		public string FooterCssClass
		{
			get => _footerCssClass ?? "default";
			set => _footerCssClass = value;
		}
		private string _footerCssClass;


		public void InsertToBreadcrumb()
		{
			InsertToBreadcrumb(new NavigationItem
			{
				Href = HomeUrl,
				InnerHtml = TitleShort
			});
		}
	}

}