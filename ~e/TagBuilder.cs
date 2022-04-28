using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text.Encodings.Web;

namespace Ans.Net6.Web
{

	// void AddCssClass(this TagBuilder tag, bool expression, string value)
	// void AddCssClasses(this TagBuilder tag, params string[] classes)
	// void AddCssClassIfPresent(this TagBuilder tag, string value)
	// void AddAttibutes(this TagBuilder tag, NameValueCollection attributes)
	// void AddAttibutes(this TagBuilder tag, object attributes)
	// void MergeAttribute(this TagBuilder tag, bool expression, string key, string value)
	// void MergeAttribute(this TagBuilder tag, bool expression, string key, string value, bool replaceExisting)
	// HtmlString ToHtml(this TagBuilder tag)

	public static partial class _e
	{

		public static void AddCssClass(
			this TagBuilder tag,
			bool expression,
			string value)
		{
			if (expression)
				tag.AddCssClass(value);
		}


		public static void AddCssClasses(
			this TagBuilder tag,
			params string[] classes)
		{
			foreach (string s1 in classes)
				tag.AddCssClassIfPresent(s1);
		}


		public static void AddCssClassIfPresent(
			this TagBuilder tag,
			string value)
		{
			if (!string.IsNullOrEmpty(value))
				tag.AddCssClass(value);
		}


		public static void AddAttibutes(
			this TagBuilder tag,
			NameValueCollection attributes)
		{
			if (attributes != null)
				foreach (var key in attributes.AllKeys)
					tag.MergeAttribute(key.Replace("__", "-"),
						attributes[key]);
		}


		public static void AddAttibutes(
			this TagBuilder tag,
			object attributes)
		{
			if (attributes != null)
				foreach (PropertyDescriptor p1 in TypeDescriptor.GetProperties(attributes))
					tag.MergeAttribute(p1.Name.Replace("__", "-"),
						p1.GetValue(attributes).ToString());
		}


		public static void MergeAttribute(
			this TagBuilder tag,
			bool expression,
			string key,
			string value)
		{
			if (expression)
				tag.MergeAttribute(key, value);
		}


		public static void MergeAttribute(
			this TagBuilder tag,
			bool expression,
			string key,
			string value,
			bool replaceExisting)
		{
			if (expression)
				tag.MergeAttribute(key, value, replaceExisting);
		}


		public static string GetString(
			this TagBuilder tag)
		{
			var writer = new StringWriter();
			tag.WriteTo(writer, HtmlEncoder.Default);
			return writer.ToString();
		}


		public static HtmlString ToHtml(
			this TagBuilder tag)
		{
			return new HtmlString(tag.GetString());
		}





		//[Obsolete("Use InnerHtml.AppendFormat()")]
		//public static void SetInnerHtml(
		//	this TagBuilder tag,
		//	string template,
		//	params object[] args)
		//{
		//	tag.InnerHtml.AppendFormat(template, args);
		//}

	}

}
