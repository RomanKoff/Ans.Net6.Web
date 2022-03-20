using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ans.Net6.Web
{

	public class TagAHelper
	{
		public string Id { get; set; }
		public string CssClass { get; set; }
		public string Href { get; set; }
		public string InnerHtml { get; set; }
		public bool IsExternal { get; set; }
		public bool IsActive { get; set; }
		public bool IsDisabled { get; set; }

		public TagBuilder GetTag()
		{
			var tag1 = new TagBuilder("a")
			{
				TagRenderMode = TagRenderMode.Normal
			};
			if (!string.IsNullOrEmpty(Id))
				tag1.MergeAttribute("id", Id);
			if (!string.IsNullOrEmpty(CssClass))
				tag1.AddCssClass(CssClass);
			tag1.MergeAttribute("href", (IsDisabled) ? "/" : Href);
			tag1.InnerHtml.AppendHtml(InnerHtml);
			if (IsActive)
			{
				tag1.AddCssClass("active");
				tag1.MergeAttribute("aria-current", "page");
			}
			if (IsExternal)
			{
				tag1.AddCssClass("external");
				tag1.MergeAttribute("target", "_blank");
			}
			if (IsDisabled)
			{
				tag1.AddCssClass("disabled");
				tag1.MergeAttribute("tabindex", "-1");
				tag1.MergeAttribute("aria-disabled", "true");
			}
			return tag1;
		}
	}

}
