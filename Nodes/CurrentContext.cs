using Ans.Net6.Common;
using Ans.Net6.Web.Providers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Ans.Net6.Web.Nodes
{

	public interface ICurrentContext
	{
		LibOptions Options { get; }
		HttpContext HttpContext { get; }
		IUrlHelper UrlHelper { get; }
		DateTimeHelper DateTimeHelper { get; }

		ISiteMapProvider SiteMapProvider { get; }
		ISiteContext Site { get; }
		INodeContext Node { get; }
		IPageContext Page { get; }

		string FixQueryPath { get; }
		string FullQueryPath { get; }
		string ViewPath { get; }
		string NodeName { get; }
		string NodePath { get; }

		string CustomBrowserTitle { get; set; }

		bool HideBreadcrumb { get; set; }

		bool AllowBreadcrumb { get; }

		string GetSiteContainer();
		string GetNodeContainer();
		string GetPageContainer();

		void SetQueryPath(string path);
		void SetViewPath(string fixPath);
		void QueryRelease();
		void SiteMapRefresh();
		void SiteMapInit(string nodeName);
		void NodeMapInit(params NodeMapItem[] items);

		HtmlString RenderBrowserTitle();
		HtmlString RenderMetas();
	}



	public class CurrentContext
		: ICurrentContext
	{

		private readonly ILogger<CurrentContext> _logger;

		public LibOptions Options { get; private set; }
		public HttpContext HttpContext { get; private set; }
		public IUrlHelper UrlHelper { get; private set; }
		public DateTimeHelper DateTimeHelper { get; private set; }

		public ISiteMapProvider SiteMapProvider { get; private set; }
		public ISiteContext Site { get; private set; }
		public INodeContext Node { get; private set; }
		public IPageContext Page { get; private set; }

		public string FixQueryPath { get; private set; }
		public string FullQueryPath { get; private set; }
		public string ViewPath { get; private set; }
		public string NodeName { get; private set; }
		public string NodePath { get; private set; }

		public string CustomBrowserTitle { get; set; }

		public bool HideBreadcrumb { get; set; }

		public bool AllowBreadcrumb
		   => !HideBreadcrumb
			   && (Site.AllowBreadcrumb
				   || Node.AllowBreadcrumb
				   || Page.AllowBreadcrumb);


		public CurrentContext(
			ILogger<CurrentContext> logger,
			IConfiguration configuration,
			IHttpContextAccessor httpContextAccessor,
			IUrlHelper urlHelper,
			ISiteMapProvider siteMapProvider,
			ISiteContext site,
			INodeContext node,
			IPageContext page)
		{
			System.Diagnostics.Debug.WriteLine("--- new CurrentContext()");
			this._logger = logger;
			this.Options = configuration.GetSection(LibOptions.Name).Get<LibOptions>();
			this.HttpContext = httpContextAccessor.HttpContext;
			this.UrlHelper = urlHelper;
			this.DateTimeHelper = new DateTimeHelper();
			this.SiteMapProvider = siteMapProvider;
			this.Site = site;
			this.Node = node;
			this.Page = page;
		}


		public string GetSiteContainer()
			=> Site.Container ?? "container";


		public string GetNodeContainer()
			=> Node.Container ?? GetSiteContainer();


		public string GetPageContainer()
			=> Page.Container ?? GetNodeContainer();


		public void SetQueryPath(
			string path)
		{
			this.FixQueryPath = (path == null) // || path == "start")
				? "" : path.TrimEnd('/');
			this.FullQueryPath = UrlHelper.Content($"~/{FixQueryPath}");
		}


		public void SetViewPath(
			string fixPath)
		{
			this.ViewPath = fixPath ?? "";
			int i1 = ViewPath.IndexOf('/');
			this.NodeName = (i1 > 0) ? ViewPath[..i1] : null;
			this.NodePath = UrlHelper.Content($"~/{NodeName}");
		}


		public void QueryRelease()
		{
			Node.SiteMapItem = SiteMapProvider.GetByName(NodeName);
			if (Node.SiteMapItem != null)
			{
				Node.Name = Node.SiteMapItem.Name;
				Node.Title = Node.SiteMapItem.Title;
				Node.ShortTitle = Node.SiteMapItem.ShortTitle;
			}
		}


		public void SiteMapRefresh()
		{
			SiteMapProvider.Refresh();
		}


		public void SiteMapInit(
			string rootName)
		{
			System.Diagnostics.Debug.WriteLine($"--- SiteMapInit(\"{rootName}\")");
			Site.Navigator = SiteMapProvider.GetByName(rootName)?.Items;
		}


		public void NodeMapInit(
			params NodeMapItem[] items)
		{
			System.Diagnostics.Debug.WriteLine("--- NodeMapInit()");
			var nav1 = new NavigationItem();
			_ = _scanNodeMap(items, nav1);
			this.Node.Navigator = nav1.Items;
		}


		public HtmlString RenderBrowserTitle()
		{
			if (!string.IsNullOrEmpty(CustomBrowserTitle))
				return new HtmlString(CustomBrowserTitle);
			var s1 = SuppString.Join(
				"{0}", null, " – ", (Page.AllowBrowserTitle) ? Page.Title : null, Node.Title, Site.Title);
			return new HtmlString(s1);
		}


		public HtmlString RenderMetas()
		{
			var sb = new StringBuilder();
			if (!string.IsNullOrEmpty(Page.MetaKeywords))
				sb.AppendLine($"<meta name=\"keywords\" content=\"{Page.MetaKeywords}\"/>");
			if (!string.IsNullOrEmpty(Page.MetaDescription))
				sb.AppendLine($"<meta name=\"description\" content=\"{Page.MetaDescription}\"/>");
			return new HtmlString(sb.ToString());
		}



		// privates

		private bool _scanNodeMap(
			IEnumerable<NodeMapItem> mapItems,
			NavigationItem master)
		{
			bool isSubActive = false;
			if (mapItems != null && mapItems.Any())
			{
				master.Items = new List<NavigationItem>();
				foreach (var item1 in mapItems)
				{
					string href = _getUrl(item1);
					bool isActive = _testUrl(href);
					if (isActive)
					{
						isSubActive = true;
						Page.Title = item1.Title;
					}
					var navItem1 = new NavigationItem()
					{
						IsTargetBlank = item1.IsTargetBlank,
						Href = href,
						IsActive = isActive,
						InnerHtml = item1.Title,
						IsHidden = item1.IsHidden
					};
					if (item1.HasItems)
						navItem1.IsSubActive = _scanNodeMap(item1.Items, navItem1);
					master.Items.Add(navItem1);
				}
			}
			return isSubActive;
		}

		private string _getUrl(
			NodeMapItem item)
		{
			if (item.IsExternal)
				return item.ExternalUrl;
			if (item.IsInternal)
				return UrlHelper.Content($"~/{item.InternalUrl}");
			return UrlHelper.Content($"~/{Node.Name}{item.Name.Make("/{0}")}");
		}

		private bool _testUrl(
			string url)
		{
			return (url.Equals(FullQueryPath));
		}

	}

}
