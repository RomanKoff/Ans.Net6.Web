using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ans.Net6.Web.TagHelpers
{
	
	/// <summary>
	/// Cсылка на адрес электронной почты
	/// </summary>
	public class AnsEmailTagHelper
		: TagHelper
	{
		public string Address { get; set; }

		public override void Process(
			TagHelperContext context,
			TagHelperOutput output)
		{
			output.TagMode = TagMode.StartTagAndEndTag;
			if (!string.IsNullOrEmpty(Address))
			{
				var a1 = Address.Split(new char[] { '@' });
				if (a1.Length == 2)
				{
					string user = a1[0];
					string host = a1[1];
					output.TagName = "a";
					output.Attributes.Add("data-user", user);
					output.Attributes.Add("data-host", host);
					return;
				}
			}
			output.TagName = "em";
			output.Content.Append("{ERROR EMAIL ADDRESS}");
		}
	}



	/// <summary>
	/// Ссылка на номер телефона
	/// </summary>
	public class AnsPhoneTagHelper
		: TagHelper
	{
		public string Number { get; set; }

		public override void Process(
			TagHelperContext context,
			TagHelperOutput output)
		{
			output.TagMode = TagMode.StartTagAndEndTag;
			if (!string.IsNullOrEmpty(Number))
			{
				string s1 = Number;
				output.TagName = "a";
				output.Attributes.Add("href", $"tel:{s1}");
				output.Content.AppendHtml(Number);
				return;
			}
			output.TagName = "em";
			output.Content.Append("{ERROR PHONE NUMBER}");
		}
	}




	///// <summary>
	///// Название страницы
	///// </summary>
	//public class AnsPageTitleTagHelper
	//	: TagHelper
	//{
	//	private readonly ICurrentContext _currentContext;

	//	[ViewContext]
	//	public ViewContext ViewContext { get; set; }

	//	public AnsPageTitleTagHelper(
	//		ICurrentContext currentContext)
	//	{
	//		this._currentContext = currentContext;
	//	}

	//	public override void Process(
	//		TagHelperContext context,
	//		TagHelperOutput output)
	//	{
	//		_pageTitleFromViewData();
	//		output.TagMode = TagMode.StartTagAndEndTag;
	//		output.TagName = "h1";
	//		output.Content.AppendHtml(_currentContext.Page.Title);
	//	}

	//	private void _pageTitleFromViewData()
	//	{
	//		if (_currentContext.Page.Title == null
	//			&& ViewContext.ViewData["Title"] != null)
	//			_currentContext.Page.Title = ViewContext.ViewData["Title"].ToString();
	//	}
	//}





	//[HtmlTargetElement("p")]
	//public class AutoLinkerHttpTagHelper
	//	: TagHelper
	//{
	//	public override async Task ProcessAsync(
	//		TagHelperContext context,
	//		TagHelperOutput output)
	//	{
	//		var childContent = output.Content.IsModified
	//			? output.Content.GetContent()
	//			: (await output.GetChildContentAsync()).GetContent();
	//		output.Content.SetHtmlContent(Regex.Replace(
	//			 childContent,
	//			 @"\b(?:https?://)(\S+)\b",
	//			 "<a target=\"_blank\" href=\"$0\">$0</a>"));
	//	}
	//}

}
