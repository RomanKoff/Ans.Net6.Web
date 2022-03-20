using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ans.Net6.Web
{

	public class TagLiHelper
	{
		public string CssClass { get; set; }
		public string InnerHtml { get; set; }

		public TagBuilder GetTag()
		{
			var tag1 = new TagBuilder("li")
			{
				TagRenderMode = TagRenderMode.Normal
			};
			if (!string.IsNullOrEmpty(CssClass))
				tag1.AddCssClass(CssClass);
			tag1.InnerHtml.AppendHtml(InnerHtml);
			return tag1;
		}
	}

}
