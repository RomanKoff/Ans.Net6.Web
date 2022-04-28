using Ans.Net6.Common;
using Microsoft.AspNetCore.Html;
using System.Text;

namespace Ans.Net6.Web
{

	// HtmlString ToHtml(this string value)
	// HtmlString ToHtml(this StringBuilder value)
	// HtmlString Render(this string value, string template)
	// HtmlString Render(this string value, string template, string nullValue)
	// HtmlString Render(this int value, string template, string format = null, int? nullValue = null)
	// HtmlString Render(this int? value, string template, string format = null)
	// HtmlString Render(this long value, string template, string format = null, long? nullValue = null)
	// HtmlString Render(this long? value, string template, string format = null)
	// HtmlString Render(this double value, string template, string format = null, double? nullValue = null)
	// HtmlString Render(this double? value, string template, string format = null)
	// HtmlString Render(this float value, string template, string format = null, float? nullValue = null)
	// HtmlString Render(this float? value, string template, string format = null)
	// HtmlString Render(this decimal value, string template, string format = null, decimal? nullValue = null)
	// HtmlString Render(this decimal? value, string template, string format = null)
	// HtmlString Render(this DateTime value, string template, string format = null)
	// HtmlString Render(this DateTime? value, string template, string format = null, string emptyText = null)
	// HtmlString Render(this bool value, string trueText, string falseText = null)

	// HtmlString RenderIf(this bool expression, string template, params object[] args)
	// HtmlString RenderUseAddons(this string value, string template, params object[] addons)
	// HtmlString RenderRepeats(this string value, int count, string resultTemplate = null, string itemTemplate = null, string itemsSeparator = null)
	// HtmlString RenderFromCollection<T>(this IEnumerable<T> items, Func<T, string> itemExtractor, string resultTemplate, string itemTemplate, string itemsSeparator)
	// HtmlString RenderFromCollection(this IEnumerable<string> items, string resultTemplate, string itemTemplate, string itemsSeparator)
	// HtmlString RenderList(this string list, string resultTemplate, string itemTemplate, string itemsSeparator)
	// HtmlString RenderUrl(this string url, string template)

	public static partial class _e
	{

		public static HtmlString ToHtml(
			this string value)
		{
			return new HtmlString(value);
		}


		public static HtmlString ToHtml(
			this StringBuilder value)
		{
			return (value.Length == 0)
				? HtmlString.Empty
				: value.ToString().ToHtml();
		}


		public static HtmlString Render(
			this string value,
			string template)
		{
			return new HtmlString(
				value.Make(template));
		}


		public static HtmlString Render(
			this string value,
			string template,
			string nullValue)
		{
			return new HtmlString(
				value.Make(template, nullValue));
		}


		public static HtmlString Render(
			this int value,
			string template,
			string format = null,
			int? nullValue = null)
		{
			return new HtmlString(
				value.Make(template, format, nullValue));
		}


		public static HtmlString Render(
			this int? value,
			string template,
			string format = null)
		{
			return new HtmlString(
				value.Make(template, format));
		}


		public static HtmlString Render(
			this long value,
			string template,
			string format = null,
			long? nullValue = null)
		{
			return new HtmlString(
				value.Make(template, format, nullValue));
		}


		public static HtmlString Render(
			this long? value,
			string template,
			string format = null)
		{
			return new HtmlString(
				value.Make(template, format));
		}


		public static HtmlString Render(
			this double value,
			string template,
			string format = null,
			double? nullValue = null)
		{
			return new HtmlString(
				value.Make(template, format, nullValue));
		}


		public static HtmlString Render(
			this double? value,
			string template,
			string format = null)
		{
			return new HtmlString(
				value.Make(template, format));
		}


		public static HtmlString Render(
			this float value,
			string template,
			string format = null,
			float? nullValue = null)
		{
			return new HtmlString(
				value.Make(template, format, nullValue));
		}


		public static HtmlString Render(
			this float? value,
			string template,
			string format = null)
		{
			return new HtmlString(
				value.Make(template, format));
		}


		public static HtmlString Render(
			this decimal value,
			string template,
			string format = null,
			decimal? nullValue = null)
		{
			return new HtmlString(
				value.Make(template, format, nullValue));
		}


		public static HtmlString Render(
			this decimal? value,
			string template,
			string format = null)
		{
			return new HtmlString(
				value.Make(template, format));
		}


		public static HtmlString Render(
			this DateTime value,
			string template,
			string format = null)
		{
			return new HtmlString(
				value.Make(template, format));
		}


		public static HtmlString Render(
			this DateTime? value,
			string template,
			string format = null,
			string emptyText = null)
		{
			return new HtmlString(
				value.Make(template, format, emptyText));
		}


		public static HtmlString Render(
			this bool value,
			string trueText,
			string falseText = null)
		{
			return new HtmlString(
				value.Make(trueText, falseText));
		}


		public static HtmlString RenderIf(
			this bool expression,
			string template,
			params object[] args)
		{
			return new HtmlString(
				expression.MakeIf(template, args));
		}

		public static HtmlString RenderUseAddons(
			this string value,
			string template,
			params object[] addons)
		{
			return new HtmlString(
				value.MakeUseAddons(template, addons));
		}

		public static HtmlString RenderRepeats(
			this string value,
			int count,
			string resultTemplate = null,
			string itemTemplate = null,
			string itemsSeparator = null)
		{
			return new HtmlString(
				value.MakeRepeats(count, resultTemplate, itemTemplate, itemsSeparator));
		}

		public static HtmlString RenderFromCollection<T>(
			this IEnumerable<T> items,
			Func<T, string> itemExtractor,
			string resultTemplate,
			string itemTemplate,
			string itemsSeparator)
		{
			return new HtmlString(
				items.MakeFromCollection(itemExtractor, resultTemplate, itemTemplate, itemsSeparator));
		}

		public static HtmlString RenderFromCollection(
			this IEnumerable<string> items,
			string resultTemplate,
			string itemTemplate,
			string itemsSeparator)
		{
			return new HtmlString(
				items.MakeFromCollection(resultTemplate, itemTemplate, itemsSeparator));
		}

		public static HtmlString RenderList(
			this string list,
			string resultTemplate,
			string itemTemplate,
			string itemsSeparator)
		{
			return new HtmlString(
				list.MakeList(resultTemplate, itemTemplate, itemsSeparator));
		}

		public static HtmlString RenderUrl(
			this string url,
			string template)
		{
			return new HtmlString(
				url.MakeUrl(template));
		}





		//public static HtmlString Render<T>(
		//	this IEnumerable<T> items,
		//	Func<T, string> itemExtractor,
		//	string resultTemplate,
		//	string itemTemplate,
		//	string itemsSeparator)
		//{
		//	return HtmlString.Create(
		//		items.Make(itemExtractor, resultTemplate, itemTemplate, itemsSeparator));
		//}

		//public static MvcHtmlString Render(
		//	this IEnumerable<string> items,
		//	string resultTemplate,
		//	string itemTemplate,
		//	string itemsSeparator)
		//{
		//	return MvcHtmlString.Create(
		//		items.Make(resultTemplate, itemTemplate, itemsSeparator));
		//}

		//public static MvcHtmlString RenderList(
		//	this string list,
		//	string resultTemplate,
		//	string itemTemplate,
		//	string itemsSeparator)
		//{
		//	return MvcHtmlString.Create(
		//		list.MakeList(resultTemplate, itemTemplate, itemsSeparator));
		//}

		//public static MvcHtmlString RenderUrl(
		//	this string url,
		//	string template)
		//{
		//	return MvcHtmlString.Create(
		//		url.MakeUrl(template));
		//}

		//public static MvcHtmlString RenderUseAddons(
		//	this string value,
		//	string template,
		//	params object[] addons)
		//{
		//	return MvcHtmlString.Create(
		//		value.MakeUseAddons(template, addons));
		//}

		//public static MvcHtmlString RenderFromRegistry(
		//	this string value,
		//	Registry registry,
		//	string template = null,
		//	string nullValue = null,
		//	bool encode = false)
		//{
		//	string s1 = value.MakeFromRegistry(
		//		registry, template, nullValue);
		//	return MvcHtmlString.Create(
		//		(encode) ? SuppView.GetHtmlEncode(s1) : s1);
		//}

		//public static MvcHtmlString RenderRepeats(
		//	this string value,
		//	int count,
		//	string resultTemplate = null,
		//	string itemTemplate = null,
		//	string itemsSeparator = null)
		//{
		//	return MvcHtmlString.Create(
		//		value.MakeRepeats(
		//			count, resultTemplate, itemTemplate, itemsSeparator));
		//}

		//public static MvcHtmlString RenderIf(
		//	this bool expression,
		//	string template,
		//	params object[] args)
		//{
		//	return MvcHtmlString.Create(
		//		expression.MakeIf(template, args));
		//}

		//public static MvcHtmlString Render_Passed(
		//	this DateTime datetime,
		//	DateTimeCalc calc,
		//	bool hasTime,
		//	bool allowYesterdayTodayTomorrow = true)
		//{
		//	return MvcHtmlString.Create(
		//		datetime.Make_Passed(
		//			calc, hasTime, allowYesterdayTodayTomorrow));
		//}

		//public static MvcHtmlString Render_Passed(
		//	this DateTime? datetime,
		//	DateTimeCalc calc,
		//	bool hasTime,
		//	bool allowYesterdayTodayTomorrow = true)
		//{
		//	return MvcHtmlString.Create(
		//		datetime.Make_Passed(
		//			calc, hasTime, allowYesterdayTodayTomorrow));
		//}

		//public static MvcHtmlString Render_Span(
		//	this DateTime date1,
		//	DateTime? date2,
		//	DateTimeCalc calc,
		//	bool hideCurrentYear = true,
		//	bool allowYesterdayTodayTomorrow = false)
		//{
		//	return MvcHtmlString.Create(
		//		date1.Make_Span(
		//			date2, calc, hideCurrentYear, allowYesterdayTodayTomorrow));
		//}

		//public static MvcHtmlString Render_SizeOfKB(
		//	this long size)
		//{
		//	return MvcHtmlString.Create(
		//		size.Make_SizeOfKB());
		//}

		//public static MvcHtmlString Render_SizeOfKB(
		//	this int size)
		//{
		//	return MvcHtmlString.Create(
		//		size.Make_SizeOfKB());
		//}

		//public static MvcHtmlString RenderCheck(
		//	this bool value,
		//	string title)
		//{
		//	return value.Render(
		//		string.Format(res_Common.Template_TrueCheck, title),
		//		string.Format(res_Common.Template_FalseCheck, title));
		//}

		//public static MvcHtmlString RenderLink(
		//	this string value,
		//	string url,
		//	string template = null)
		//{
		//	if (string.IsNullOrEmpty(url))
		//		return value.Render();
		//	string s1 = string.Format(
		//		"<a target='_blank' href='{1}'>{0}</a>",
		//		value, url);
		//	return s1.Render(template);
		//}

	}

}
