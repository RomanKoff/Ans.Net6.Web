namespace Ans.Net6.Web.Nodes
{

	public interface I_CommonContext
	{
		List<NavigationItem> Breadcrumb { get; set; }

		string Title { get; set; }
		string Container { get; set; }
		bool HideBreadcrumb { get; set; }
		bool AllowBreadcrumb { get; }

		void InsertToBreadcrumb(NavigationItem link);
	}



	public class _CommonContext_Base
		: I_CommonContext
	{
		public List<NavigationItem> Breadcrumb { get; set; }

		public string Title { get; set; }
		public string Container { get; set; }
		public bool HideBreadcrumb { get; set; }

		public bool AllowBreadcrumb
			=> !HideBreadcrumb && Breadcrumb != null && Breadcrumb.Any();

		public void InsertToBreadcrumb(
			NavigationItem link)
		{
			if (Breadcrumb == null)
				this.Breadcrumb = new List<NavigationItem>();
			Breadcrumb.Insert(0, link);
		}
	}

}