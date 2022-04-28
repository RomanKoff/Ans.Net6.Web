namespace Ans.Net6.Web.Nodes
{

	public interface INodeContext
		: I_CommonContext
	{
		SiteMapItem SiteMapItem { get; set; }
		List<NavigationItem> Navigator { get; set; }

		string Name { get; set; }
		string ShortTitle { get; set; }

		bool HideNavigator { get; set; }

		bool AllowNavigator { get; }
	}



	public class NodeContext
		: _CommonContext_Base,
		INodeContext
	{
		private string _shortTitle;

		public SiteMapItem SiteMapItem { get; set; }
		public List<NavigationItem> Navigator { get; set; }

		public string Name { get; set; }
		public string ShortTitle { get => _shortTitle ?? Title; set => _shortTitle = value; }

		public bool HideNavigator { get; set; }

		public bool AllowNavigator
			=> !HideNavigator && Navigator != null && Navigator.Any();

		public NodeContext()
		{
			System.Diagnostics.Debug.WriteLine("--- new NodeContext()");
		}
	}

}