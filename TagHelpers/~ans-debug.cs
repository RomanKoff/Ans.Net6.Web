using Ans.Net6.Web.Nodes;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ans.Net6.Web.TagHelpers
{

	public class AnsDebugCurrentTagHelper
		: TagHelper
	{
		private readonly ICurrentContext _current;

		public AnsDebugCurrentTagHelper(
			ICurrentContext currentContext)
		{
			this._current = currentContext;
		}

		public override void Process(
			TagHelperContext context,
			TagHelperOutput output)
		{
			output.TagMode = TagMode.StartTagAndEndTag;
			output.TagName = "div";
			output.Content.AppendHtml($"<h3>Current</h3>");
			_addItem(output, "QueryPath", _current.QueryPath);
			_addItem(output, "ViewPath", _current.ViewPath);
			_addItem(output, "NodeName", _current.NodeName);
			_addItem(output, "NodePath", _current.NodePath);

			//output.Content.AppendHtml("<div class=\"row\"><div class=\"col\">");
			//_addItem(output, cc.ResourceHost, "ResourceHost");
			//_addItem(output, cc.Lang, "Lang");
			//_addItem(output, cc.BrowserTitleCustom, "BrowserTitleCustom");
			//_addItem(output, cc.FaviconRel, "FaviconRel");
			//_addItem(output, cc.FaviconType, "FaviconType");
			//_addItem(output, cc.FaviconHref, "FaviconHref");
			//_addItem(output, cc.FaviconCodeCustom, "FaviconCodeCustom");
			//_addItem(output, cc.MetaKeywords, "MetaKeywords");
			//_addItem(output, cc.MetaDescription, "MetaDescription");
			//_addItem(output, cc.HideBreadcrumb, "HideBreadcrumb");

			//output.Content.AppendHtml("</div><div class=\"col\">");
			//_addItem(output, cc.QueryPath, "QueryPath");
			//_addItem(output, cc.ViewPath, "ViewPath");
			//_addItem(output, cc.NodeName, "NodeName");
			//_addItem(output, cc.NodePath, "NodePath");
			//_addItem(output, cc.AllowBreadcrumb, "AllowBreadcrumb");

			//output.Content.AppendHtml("</div></div>");
		}

		private void _addItem(
			TagHelperOutput output,
			string title,
			string value)
		{
			output.Content.AppendHtml($"{title}: <code>{value}</code><br/>");
		}

		//private void _addItem(
		//    TagHelperOutput output,
		//    bool value,
		//    string title)
		//{
		//    _addItem(output, value.ToString(), title);
		//}
	}



	public class AnsDebugDisplayTagHelper
		: TagHelper
	{
		public override void Process(
			TagHelperContext context,
			TagHelperOutput output)
		{
			output.TagMode = TagMode.StartTagAndEndTag;
			output.TagName = null;
			output.Content.AppendHtml(
				"<code class='debug-display d-block d-sm-none'>" +
					"<b>XS</b> &lt;576(c:auto)</code>" +
				"<code class='debug-display d-none d-sm-block d-md-none'>" +
					"<b>SM</b> ≥576(c:540)</code>" +
				"<code class='debug-display d-none d-md-block d-lg-none'>" +
					"<b>MD</b> ≥720(c:720)</code>" +
				"<code class='debug-display d-none d-lg-block d-xl-none'>" +
					"<b>LG</b> ≥960(c:960)</code>" +
				"<code class='debug-display d-none d-xl-block d-xxl-none'>" +
					"<b>XL</b> ≥1200(c:1140)</code>" +
				"<code class='debug-display d-none d-xxl-block'>" +
					"<b>XXL</b> ≥1400(c:1320)</code>");
		}
	}



	//public class AnsDebugNodesTagHelper
	//    : TagHelper
	//{
	//    private readonly IMapNodesProvider _mapNodes;
	//    private readonly ICurrentContext _currentContext;

	//    public AnsDebugNodesTagHelper(
	//        IMapNodesProvider mapNodes,
	//        ICurrentContext currentContext)
	//    {
	//        this._mapNodes = mapNodes;
	//        this._currentContext = currentContext;
	//    }

	//    public override void Process(
	//        TagHelperContext context,
	//        TagHelperOutput output)
	//    {
	//        if (_mapNodes != null)
	//        {
	//            output.TagMode = TagMode.StartTagAndEndTag;
	//            output.TagName = "div";
	//            output.Content.AppendHtml($"<p>Node: <code>{_currentContext.NodeName}</code></p>");
	//            output.Content.AppendHtml("<ul>");
	//            _outNodes(output, _mapNodes.Root);
	//            output.Content.AppendHtml("</ul>");
	//        }
	//    }

	//    private void _outNodes(
	//        TagHelperOutput output,
	//        MapNodeItem item)
	//    {
	//        output.Content.AppendHtml("<li>");
	//        output.Content.AppendHtml($"<code>[{item.Id}^{item.MasterPtr}]</code> ");
	//        output.Content.AppendHtml($"<a href=\"{_currentContext.BaseUrl}/{item.Name}\">{item.Name} - {item.Title}</a>");
	//        output.Content.AppendHtml($" <code>({item.CountMasters}:{item.CountSlaves})</code>");
	//        if (item.Slaves != null && item.Slaves.Any())
	//        {
	//            output.Content.AppendHtml("<ul>");
	//            foreach (var item1 in item.Slaves)
	//                _outNodes(output, item1);
	//            output.Content.AppendHtml("</ul>");
	//        }
	//        output.Content.AppendHtml("</li>");
	//    }
	//}



	//public class AnsDebugNavigationTagHelper
	//    : TagHelper
	//{
	//    private readonly ICurrentContext _currentContext;

	//    public AnsDebugNavigationTagHelper(
	//        ICurrentContext currentContext)
	//    {
	//        this._currentContext = currentContext;
	//    }

	//    public override void Process(
	//        TagHelperContext context,
	//        TagHelperOutput output)
	//    {
	//        if (_currentContext.Node.Navigator != null)
	//        {
	//            output.TagMode = TagMode.StartTagAndEndTag;
	//            output.TagName = "div";
	//            output.Content.AppendHtml($"<p>Node path: <code>{_currentContext.NodePath}</code></p>");
	//            output.Content.AppendHtml("<ul>");
	//            _outBranch(output, _currentContext.Node.Navigator);
	//            output.Content.AppendHtml("</ul>");
	//        }
	//    }

	//    private void _outBranch(
	//        TagHelperOutput output,
	//        NavigatorBranch branch)
	//    {
	//        if (branch != null && branch.Any())
	//        {
	//            output.Content.AppendHtml("<ul>");
	//            foreach (var item1 in branch)
	//            {
	//                output.Content.AppendHtml("<li>");
	//                output.Content.AppendHtml(item1.Href);
	//                if (item1.IsSubActive)
	//                    output.Content.AppendHtml("<b>.S</b>");
	//                if (item1.IsActive)
	//                    output.Content.AppendHtml("<b>.A</b>");
	//                if (item1.IsHidden)
	//                    output.Content.AppendHtml("<b>.H</b>");
	//                output.Content.AppendHtml(" - ");
	//                output.Content.AppendHtml(item1.GetTag());
	//                output.Content.AppendHtml("</li>");
	//                _outBranch(output, item1);
	//            }
	//            output.Content.AppendHtml("</ul>");
	//        }
	//    }
	//}





}
