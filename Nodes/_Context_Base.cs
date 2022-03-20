namespace Ans.Net6.Web.Nodes
{

	public interface I_Context_Base
	{
		string Title { get; set; }
		string TitleShort { get; set; }
		string Container { get; set; }
		List<NavigationItem> Breadcrumb { get; set; }
		bool HideBreadcrumb { get; set; }
		bool AllowBreadcrumb { get; }

		void InsertToBreadcrumb(NavigationItem link);
	}


	public class _Context_Base
		: I_Context_Base
	{
		public string Title { get; set; }

		public string TitleShort
		{
			get => _titleShort ?? Title;
			set => _titleShort = value;
		}
		private string _titleShort;

		public string Container { get; set; }

		public List<NavigationItem> Breadcrumb { get; set; }

		public bool HideBreadcrumb { get; set; }

		public bool AllowBreadcrumb
			=> !HideBreadcrumb
				&& Breadcrumb != null
				&& Breadcrumb.Any();

		public void InsertToBreadcrumb(
			NavigationItem link)
		{
			if (Breadcrumb == null)
				this.Breadcrumb = new List<NavigationItem>();
			Breadcrumb.Insert(0, link);
		}
	}

}