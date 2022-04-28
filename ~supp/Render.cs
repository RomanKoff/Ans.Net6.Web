using Ans.Net6.Common;
using Microsoft.AspNetCore.Html;

namespace Ans.Net6.Web
{

	// HtmlString Join(string templateResult, string templateItem, string itemsSeparator, params string[] data)
	// HtmlString Join(string templateResult, string templateItem, string itemsSeparator, string data, string dataSeparator)

	public static class Render
	{

		public static HtmlString Join(
			string templateResult,
			string templateItem,
			string itemsSeparator,
			params string[] data)
		{
			return new HtmlString(
				SuppString.Join(
					templateResult, templateItem, itemsSeparator,
					data));
		}


		public static HtmlString Join(
			string templateResult,
			string templateItem,
			string itemsSeparator,
			string data,
			string dataSeparator)
		{
			return Join(
				templateResult, templateItem, itemsSeparator,
				data.Split(dataSeparator));
		}

	}

}
