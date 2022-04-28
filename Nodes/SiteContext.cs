namespace Ans.Net6.Web.Nodes
{

	public interface ISiteContext
		: I_CommonContext
	{
		List<SiteMapItem> Navigator { get; set; }
		string HomeUrl { get; set; }

		bool HideNavigator { get; set; }

		bool AllowNavigator { get; }
	}



	public class SiteContext
		: _CommonContext_Base,
		ISiteContext
	{
		public List<SiteMapItem> Navigator { get; set; }
		public string HomeUrl { get; set; }

		public bool HideNavigator { get; set; }

		public bool AllowNavigator
			=> !HideNavigator && Navigator != null && Navigator.Any();

		public SiteContext()
		{
			System.Diagnostics.Debug.WriteLine("--- new SiteContext()");
		}
	}

}