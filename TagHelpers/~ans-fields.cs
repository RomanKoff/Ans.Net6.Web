using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// ans-field-text
/// </summary>
namespace Ans.Net6.Web.TagHelpers
{

	public class AnsFieldTextTagHelper
		: TagHelper
	{
		public string Name { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Sample { get; set; }
		public string HelpLink { get; set; }

		public override void Process(
			TagHelperContext context,
			TagHelperOutput output)
		{
			output.TagMode = TagMode.StartTagAndEndTag;
			output.TagName = "div";
			output.Attributes.Add("class", "form-group");
			output.Content.AppendHtml(
				$"<label for='{Name}'>{Title}</label>");
			output.Content.AppendHtml(
				$"<input class='form-control' name='{Name}' id='{Name}' type='text' />");
		}
	}

}
