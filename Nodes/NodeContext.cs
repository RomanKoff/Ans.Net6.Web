namespace Ans.Net6.Web.Nodes
{

	public interface INodeContext
		: I_Context_Base
	{
		string Name { get; set; }
		string ParentTitle { get; set; }
		string ParentUrl { get; set; }
		string HeaderCssClass { get; set; }
		string FooterCssClass { get; set; }
		bool HideHeader { get; set; }
		bool HideFooter { get; set; }
		bool HideParent { get; set; }
		bool AllowFooter { get; }
		bool AllowHeader { get; }
		bool AllowParent { get; }
	}


	public class NodeContext
		: _Context_Base,
		INodeContext
	{
		public string Name { get; set; }

		public string ParentTitle { get; set; }

		public string ParentUrl { get; set; }

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

		public bool HideHeader { get; set; }
		public bool HideFooter { get; set; }
		public bool HideParent { get; set; }

		public bool AllowHeader
			=> !HideHeader;

		public bool AllowFooter
			=> !HideFooter;

		public bool AllowParent
			=> !HideParent
				&& !string.IsNullOrEmpty(ParentTitle);
	}

}