using Ans.Net6.Web.Nodes;
using Microsoft.AspNetCore.Razor.TagHelpers;

// ans-debug-current
// ans-debug-display

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
			_addItem(output, "QueryPathLocal", _current.FixQueryPath);
			_addItem(output, "QueryPathFull", _current.FullQueryPath);
			_addItem(output, "ViewPath", _current.ViewPath);
			_addItem(output, "NodeName", _current.NodeName);
			_addItem(output, "NodePath", _current.NodePath);
		}

		private static void _addItem(
			TagHelperOutput output,
			string title,
			string value)
		{
			output.Content.AppendHtml($"{title}: <code>{value}</code><br/>");
		}
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
				"<code class='debug-display d-block d-sm-none'><b>XS</b> &lt;576(c:auto)</code>" +
				"<code class='debug-display d-none d-sm-block d-md-none'><b>SM</b> ≥576(c:540)</code>" +
				"<code class='debug-display d-none d-md-block d-lg-none'><b>MD</b> ≥720(c:720)</code>" +
				"<code class='debug-display d-none d-lg-block d-xl-none'><b>LG</b> ≥960(c:960)</code>" +
				"<code class='debug-display d-none d-xl-block d-xxl-none'><b>XL</b> ≥1200(c:1140)</code>" +
				"<code class='debug-display d-none d-xxl-block'><b>XXL</b> ≥1400(c:1320)</code>");
		}
	}

}
