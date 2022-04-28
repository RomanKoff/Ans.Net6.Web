using Microsoft.AspNetCore.Razor.TagHelpers;

// ans-email
// ans-phone

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

}
