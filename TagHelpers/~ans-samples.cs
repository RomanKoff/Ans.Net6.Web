using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// ans-sample-ru
/// ans-sample-ru-small
/// ans-sample-ru-smaller
/// </summary>
namespace Ans.Net6.Web.TagHelpers
{

	public class AnsSampleRuTagHelper
		: TagHelper
	{
		public override void Process(
			TagHelperContext context,
			TagHelperOutput output)
		{
			output.TagMode = TagMode.StartTagAndEndTag;
			output.TagName = null;
			output.Content.AppendHtml(Common._Const.GetSampleRu());
		}
	}



	public class AnsSampleRuSmallTagHelper
		: TagHelper
	{
		public override void Process(
			TagHelperContext context,
			TagHelperOutput output)
		{
			output.TagMode = TagMode.StartTagAndEndTag;
			output.TagName = null;
			output.Content.AppendHtml(Common._Const.GetSampleRu_Small());
		}
	}



	public class AnsSampleRuSmallerTagHelper
		: TagHelper
	{
		public override void Process(
			TagHelperContext context,
			TagHelperOutput output)
		{
			output.TagMode = TagMode.StartTagAndEndTag;
			output.TagName = null;
			output.Content.AppendHtml(Common._Const.GetSampleRu_Smaller());
		}
	}

}
