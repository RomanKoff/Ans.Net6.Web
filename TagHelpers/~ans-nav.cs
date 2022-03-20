using Ans.Net6.Web.Nodes;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ans.Net6.Web.TagHelpers
{

	public class AnsNavLinkTagHelper
		: TagHelper
	{
		public NavigationItem Item { get; set; }
		public string Class { get; set; }

		public override void Process(
			TagHelperContext context,
			TagHelperOutput output)
		{
			output.TagMode = TagMode.StartTagAndEndTag;
			output.TagName = null;
			var tag1 = new TagAHelper
			{
				CssClass = Class,
				Href = Item.Href,
				InnerHtml = Item.InnerHtml,
				IsActive = Item.IsActive,
				IsExternal = Item.IsBlank
			};
			output.Content.AppendHtml(tag1.GetTag());
		}
	}



	public class AnsBreadcrumbTagHelper
		: TagHelper
	{
		private readonly ICurrentContext _current;

		public List<NavigationItem> Items { get; set; }


		public AnsBreadcrumbTagHelper(
			ICurrentContext current)
		{
			this._current = current;
		}


		public override void Process(
			TagHelperContext context,
			TagHelperOutput output)
		{
			/*
			<nav aria-label="breadcrumb">
			 <ol class="breadcrumb">
				 <li class="breadcrumb-item"><a href="#">Home</a></li>
				 <li class="breadcrumb-item"><a href="#">Library</a></li>
				 <li class="breadcrumb-item active" aria-current="page">Data</li>
			 </ol>
			</nav>
			*/
			var data = Items ?? _current.GetBreadcrumb();
			if (data != null && data.Any())
			{
				output.TagMode = TagMode.StartTagAndEndTag;
				output.TagName = "nav";
				output.Attributes.Add("aria-label", "breadcrumb");
				output.Content.AppendHtml("\n<ol class=\"breadcrumb\">");
				foreach (var item1 in data.Take(data.Count - 1))
					if (item1.IsDisabled)
					{
						output.Content.AppendHtml("\n<li class=\"breadcrumb-item disabled\">");
						output.Content.AppendHtml(item1.InnerHtml);
						output.Content.AppendHtml("</li>");
					}
					else
					{
						output.Content.AppendHtml("\n<li class=\"breadcrumb-item\">");
						output.Content.AppendHtml($"<a href=\"{item1.Href}\">{item1.InnerHtml}</a>");
						output.Content.AppendHtml("</li>");
					}
				var item2 = data.Last();
				output.Content.AppendHtml("\n<li class=\"breadcrumb-item active\" aria-current=\"page\">");
				output.Content.AppendHtml(item2.InnerHtml);
				output.Content.AppendHtml("</li>");
				output.Content.AppendHtml("\n</ol>");
			}
		}

	}



	//public class AnsNavItemTagHelper
	//	: TagHelper
	//{
	//	public string ClassLi { get; set; }
	//	public string ClassA { get; set; }
	//	public string Href { get; set; }
	//	public bool External { get; set; }
	//	public bool Active { get; set; }
	//	public bool Disabled { get; set; }
	//	public override void Process(
	//		TagHelperContext context,
	//		TagHelperOutput output)
	//	{
	//		output.TagMode = TagMode.StartTagAndEndTag;
	//		output.TagName = null;
	//		var a1 = new TagAHelper
	//		{
	//			CssClass = (ClassA == "") ? null : ClassA ?? "nav-link",
	//			Href = Href,
	//			InnerHtml = output.GetChildContentAsync().Result.GetContent(),
	//			IsExternal = External,
	//			IsActive = Active,
	//			IsDisabled = Disabled
	//		};
	//		var li1 = new TagLiHelper
	//		{
	//			CssClass = (ClassLi == "") ? null : ClassLi ?? "nav-item",
	//			InnerHtml = a1.GetTag().GetString()
	//		};
	//		output.Content.AppendHtml(li1.GetTag());
	//	}
	//}



	///// <summary>
	///// Элементы навигации
	///// </summary>
	//public class AnsNavbarItemsTagHelper
	//	: TagHelper
	//{
	//	private readonly ICurrentContext _currentContext;
	//	public string Id { get; set; }
	//	public NavigatorBranch Data { get; set; }
	//	public AnsNavbarItemsTagHelper(
	//		ICurrentContext currentContext)
	//	{
	//		this._currentContext = currentContext;
	//	}
	//	public override void Process(
	//		TagHelperContext context,
	//		TagHelperOutput output)
	//	{
	//		if (Data != null && Data.Any())
	//		{
	//			var id = Id ?? $"ddl_{context.UniqueId}";
	//			output.TagMode = TagMode.StartTagAndEndTag;
	//			output.TagName = null;
	//			int i1 = 0;
	//			foreach (var item1 in Data.Where(x => !x.IsHidden))
	//			{
	//				var li1 = new TagBuilder("li");
	//				li1.AddCssClass("nav-item");
	//				var link1 = item1.GetTag();
	//				link1.AddCssClass("nav-link");
	//				if (item1.IsSubActive)
	//					link1.AddCssClass("active");
	//				if (item1.Any())
	//				{
	//					var id2 = $"{id}_{++i1}";
	//					li1.AddCssClass("dropdown");
	//					link1.AddCssClass("dropdown-toggle");
	//					link1.MergeAttribute("id", id2);
	//					link1.MergeAttribute("role", "button");
	//					link1.MergeAttribute("data-bs-toggle", "dropdown");
	//					link1.MergeAttribute("aria-expanded", "false");
	//					li1.InnerHtml.AppendHtml(link1);
	//					var ul1 = new TagBuilder("ul");
	//					ul1.AddCssClass("dropdown-menu");
	//					ul1.MergeAttribute("aria-labelledby", id2);
	//					foreach (var item2 in item1.Where(x => !x.IsHidden))
	//					{
	//						var li2 = new TagBuilder("li");
	//						var link2 = item2.GetTag();
	//						link2.AddCssClass("dropdown-item");
	//						li2.InnerHtml.AppendHtml(link2);
	//						ul1.InnerHtml.AppendHtml(li2);
	//					}
	//					li1.InnerHtml.AppendHtml(ul1);
	//				}
	//				else
	//				{
	//					li1.InnerHtml.AppendHtml(link1);
	//				}
	//				output.Content.AppendHtml(li1);
	//			}
	//		}
	//	}
	//}



	///// <summary>
	///// Навигатор
	///// </summary>
	//public class AnsNavigatorTagHelper
	//	: TagHelper
	//{
	//	private readonly ICurrentContext _currentContext;
	//	public string Id { get; set; }
	//	public NavigatorBranch Data { get; set; }
	//	public AnsNavigatorTagHelper(
	//		ICurrentContext currentContext)
	//	{
	//		this._currentContext = currentContext;
	//	}
	//	public override void Process(
	//		TagHelperContext context,
	//		TagHelperOutput output)
	//	{
	//		var data = Data ?? _currentContext.Node.Navigator;
	//		if (data != null && data.Any())
	//		{
	//			var id = Id ?? $"ddl_{context.UniqueId}";
	//			output.TagMode = TagMode.StartTagAndEndTag;
	//			output.TagName = "ul";
	//			output.Attributes.Add("class", "navigator");
	//			int i1 = 0;
	//			foreach (var item1 in data.Where(x => !x.IsHidden))
	//			{
	//				if (item1.Any())
	//				{
	//					var id2 = $"{id}_{++i1}";
	//					output.Content.AppendHtml("\n<li class=\"dropdown\">");
	//					var link1 = item1.GetTag();
	//					link1.AddCssClass("dropdown-toggle");
	//					link1.MergeAttribute("id", id2);
	//					link1.MergeAttribute("role", "button");
	//					link1.MergeAttribute("data-bs-toggle", "dropdown");
	//					link1.MergeAttribute("aria-expanded", "false");
	//					output.Content.AppendHtml(link1);
	//					output.Content.AppendHtml($"\n\t<ul class=\"dropdown-menu\" aria-labelledby=\"{id2}\">");
	//					foreach (var item2 in item1.Where(x => !x.IsHidden))
	//					{
	//						output.Content.AppendHtml("\n\t\t<li>");
	//						var link2 = item2.GetTag();
	//						link2.AddCssClass("dropdown-item");
	//						output.Content.AppendHtml(link2);
	//						output.Content.AppendHtml("</li>");
	//					}
	//					output.Content.AppendHtml("\n\t</ul>");
	//				}
	//				else
	//				{
	//					output.Content.AppendHtml("\n<li>");
	//					output.Content.AppendHtml(item1.GetTag());
	//				}
	//				output.Content.AppendHtml("\n</li>");
	//			}
	//		}
	//	}
	//}

}
