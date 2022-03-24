using Ans.Net6.Common;
using Microsoft.AspNetCore.Html;

namespace Ans.Net6.Web
{

	public static class Render
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="templateResult"></param>
		/// <param name="templateItem"></param>
		/// <param name="itemsSeparator"></param>
		/// <param name="data"></param>
		/// <returns></returns>
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


		/// <summary>
		/// 
		/// </summary>
		/// <param name="templateResult"></param>
		/// <param name="templateItem"></param>
		/// <param name="itemsSeparator"></param>
		/// <param name="data"></param>
		/// <param name="dataSeparator"></param>
		/// <returns></returns>
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
