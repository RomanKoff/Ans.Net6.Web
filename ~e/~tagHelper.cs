using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ans.Net6.Web
{

	/// <summary>
	/// void AppendInfo(this TagHelperContent content, string title, object data)	
	/// </summary>
	public static partial class _e
	{

		public static void AppendInfo(
			this TagHelperContent content,
			string title,
			object data)
		{
			string s1 = (data == null) ? "[Null]" : data.ToString();
			string s2 = (s1 == string.Empty) ? "[Empty]" : s1;
			content.AppendHtml($"<var>{title}</var> =&nbsp;<code>{s2}</code><br/>");
		}

	}

}
