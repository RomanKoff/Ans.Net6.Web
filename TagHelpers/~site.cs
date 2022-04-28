using Ans.Net6.Web.Nodes;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ans.Net6.Web.TagHelpers
{

	//public class SiteMapTagHelper
	//	: TagHelper
	//{
	//	private readonly ISiteMapProvider _sitemap;
	//	private readonly IUrlHelper _url;
	//
	//	public SiteMapTagHelper(
	//		ISiteMapProvider sitemap,
	//		IUrlHelper url)
	//	{
	//		this._sitemap = sitemap;
	//		this._url = url;
	//	}
	//
	//	public override void Process(
	//		TagHelperContext context,
	//		TagHelperOutput output)
	//	{
	//		output.TagMode = TagMode.StartTagAndEndTag;
	//		output.TagName = "div";
	//		output.Attributes.Add("class", "sitemap");
	//		if (_sitemap.Items != null)
	//			_scan(output, _sitemap.Items);
	//	}
	//
	//	// privates
	//
	//	private void _scan(
	//		TagHelperOutput output,
	//		List<SiteMapItem> items)
	//	{
	//		output.Content.AppendHtml("<ul>");
	//		foreach (var item1 in items)
	//		{
	//			string title = $"{item1.Title}{item1.HasShortTitle.MakeIf(" ({0})", item1.ShortTitle)}";
	//			if (item1.IsGroup)
	//			{
	//				// group
	//				output.Content.AppendHtml($"<li class=\"sitemap-group\">{title}");
	//			}
	//			else
	//			{
	//				output.Content.AppendHtml("<li>");
	//				if (item1.HasLink)
	//				{
	//					// link
	//					if (item1.IsExternal)
	//					{
	//						// external
	//						output.Content.AppendHtml(
	//							$"<a target=\"_blank\" class=\"link-external\" href=\"{item1.ExternalUrl}\">{title}</a>");
	//					}
	//					else
	//					{
	//						// internal
	//						string url = _url.Content($"~/{item1.Name}");
	//						output.Content.AppendHtml(
	//							$"<a href=\"{url}\">{title}</a>");
	//					}
	//				}
	//				else
	//				{
	//					// plug
	//					output.Content.AppendHtml(title);
	//				}
	//			}
	//			if (item1.HasItems)
	//				_scan(output, item1.Items);
	//			output.Content.AppendHtml("</li>");
	//		}
	//		output.Content.AppendHtml("\n</ul>");
	//	}
	//}



	//public class NodeMapTagHelper
	//	: TagHelper
	//{
	//	private readonly ICurrentContext _current;
	//
	//	public NodeMapTagHelper(
	//		ICurrentContext context)
	//	{
	//		this._current = context;
	//	}
	//
	//	public override void Process(
	//		TagHelperContext context,
	//		TagHelperOutput output)
	//	{
	//		output.TagMode = TagMode.StartTagAndEndTag;
	//		output.TagName = "div";
	//		output.Attributes.Add("class", "nodemap");
	//		if (_current.Node.Navigation != null)
	//			_scan(output, _current.Node.Navigation);
	//	}
	//
	//	// privates
	//
	//	private void _scan(
	//		TagHelperOutput output,
	//		List<NavigationItem> items)
	//	{
	//		output.Content.AppendHtml("<ul>");
	//		foreach (var item1 in items)
	//		{
	//			output.Content.AppendHtml("<li>");
	//			if (item1.HasItems)
	//			{
	//				output.Content.AppendHtml($"{item1.InnerHtml} [{item1.IsActive}:{item1.IsSubActive}]");
	//				_scan(output, item1.Items);
	//			}
	//			else
	//			{
	//				if (item1.IsTargetBlank)
	//				{
	//					// external
	//					output.Content.AppendHtml(
	//						$"<a target=\"_blank\" class=\"link-external\" href=\"{item1.Href}\">{item1.InnerHtml}</a>");
	//				}
	//				else
	//				{
	//					// internal						
	//					output.Content.AppendHtml(
	//						$"<a href=\"{item1.Href}\">{item1.InnerHtml} [{item1.IsActive}:{item1.IsSubActive}]</a>");
	//				}
	//			}
	//			output.Content.AppendHtml("</li>");
	//		}
	//		output.Content.AppendHtml("\n</ul>");
	//	}
	//}



	//public class NodeSlavesTagHelper
	//	: TagHelper
	//{
	//	private readonly ICurrentContext _current;
	//
	//	public NodeSlavesTagHelper(
	//		ICurrentContext current)
	//	{
	//		this._current = current;
	//	}
	//
	//	public override void Process(
	//		TagHelperContext context,
	//		TagHelperOutput output)
	//	{
	//		output.TagMode = TagMode.StartTagAndEndTag;
	//		output.TagName = "div";
	//		output.Attributes.Add("class", "nodeslaves");
	//		if (_current.Node.SiteMapItem != null && _current.Node.SiteMapItem.HasMasters)
	//		{
	//			output.Content.AppendHtml("<ul>");
	//			foreach (var item1 in _current.Node.SiteMapItem.Masters)
	//			{
	//				output.Content.AppendHtml($"<li><a href=\"{item1.Name}\">{item1.ShortTitle}</a></li>");
	//			}
	//			output.Content.AppendHtml("\n</ul>");
	//		}
	//	}
	//}

}
