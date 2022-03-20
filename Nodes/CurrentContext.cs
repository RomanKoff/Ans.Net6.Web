using Ans.Net6.Common;
using Ans.Net6.Web.Services;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text;

namespace Ans.Net6.Web.Nodes
{

	public interface ICurrentContext
	{
		HttpContext HttpContext { get; }
		IUrlHelper UrlHelper { get; }
		DateTimeHelper DateTimeHelper { get; }
		ISiteContext Site { get; }
		INodeContext Node { get; }
		IPageContext Page { get; }
		string QueryPath { get; }
		string ViewPath { get; }
		string NodeName { get; }
		string NodePath { get; }

		string CustomBrowserTitle { get; set; }
		string BreadcrumbCssClass { get; set; }
		bool HideBreadcrumb { get; set; }

		bool AllowBreadcrumb { get; }

		void SetQueryPath(string path);
		void SetViewPath(string path);

		string GetSiteContainer();
		string GetNodeContainer();
		string GetPageContainer();
		List<NavigationItem> GetBreadcrumb();

		NavigationTree GetNavigationByName(string name, string basePath);
		NavigationTree GetNavigationByPath(string path, string basePath);
		NavigationTree GetNavigationByPath(string path);

		HtmlString RenderBrowserTitle();
		HtmlString RenderMetas();
	}



	public class CurrentContext
		: ICurrentContext
	{

		private readonly ILogger<CurrentContext> _logger;
		private readonly IConfiguration _configuration;
		private readonly LibOptions _options;
		private readonly INavProviderService _navProvider;

		public HttpContext HttpContext { get; private set; }
		public IUrlHelper UrlHelper { get; private set; }
		public DateTimeHelper DateTimeHelper { get; private set; }
		public ISiteContext Site { get; private set; }
		public INodeContext Node { get; private set; }
		public IPageContext Page { get; private set; }
		public string QueryPath { get; private set; }
		public string ViewPath { get; private set; }
		public string NodeName { get; private set; }
		public string NodePath { get; private set; }

		public string CustomBrowserTitle { get; set; }


		public CurrentContext(
			ILogger<CurrentContext> logger,
			IConfiguration configuration,
			IHttpContextAccessor httpContextAccessor,
			INavProviderService navProvider,
			IUrlHelper urlHelper,
			ISiteContext site,
			INodeContext node,
			IPageContext page)
		{
			Debug.WriteLine("--- new CurrentContext()");
			this._logger = logger;
			this._configuration = configuration;
			this._options = configuration.GetSection(LibOptions.Name).Get<LibOptions>();
			this.HttpContext = httpContextAccessor.HttpContext;
			this._navProvider = navProvider;
			this.UrlHelper = urlHelper;
			this.DateTimeHelper = new DateTimeHelper();
			this.Site = site;
			this.Node = node;
			this.Page = page;
		}


		public void SetQueryPath(
			string path)
		{
			this.QueryPath = (path == null)
				? "" : path.TrimEnd('/');
		}

		public void SetViewPath(
			string path)
		{
			this.ViewPath = path ?? "";
			int i1 = ViewPath.IndexOf('/');
			this.NodeName = (i1 > 0) ? ViewPath[..i1] : null;
			this.NodePath = UrlHelper.Content($"~/{NodeName}");
		}


		public string BreadcrumbCssClass
		{
			get => _breadcrumbCssClass ?? "default";
			set => _breadcrumbCssClass = value;
		}
		private string _breadcrumbCssClass;


		public bool HideBreadcrumb { get; set; }


		public bool AllowBreadcrumb
		   => !HideBreadcrumb
			   && (Site.AllowBreadcrumb
				   || Node.AllowBreadcrumb
				   || Page.AllowBreadcrumb);


		public string GetSiteContainer()
			=> Site.Container ?? "container";

		public string GetNodeContainer()
			=> Node.Container ?? GetSiteContainer();

		public string GetPageContainer()
			=> Page.Container ?? GetNodeContainer();

		public List<NavigationItem> GetBreadcrumb()
		{
			var items = new List<NavigationItem>();
			if (Site.AllowBreadcrumb)
				items.AddRange(Site.Breadcrumb);
			if (Node.AllowBreadcrumb)
				items.AddRange(Node.Breadcrumb);
			if (Page.AllowBreadcrumb)
				items.AddRange(Page.Breadcrumb);
			return items;
		}


		public NavigationTree GetNavigationByName(
			string name,
			string basePath)
		{
			var nav1 = _navProvider.GetItemByName(name);
			return new NavigationTree(QueryPath, basePath, nav1);
		}

		public NavigationTree GetNavigationByPath(
			string path,
			string basePath)
		{
			var nav1 = _navProvider.GetItemByPath(path ?? $"/{QueryPath}");
			return new NavigationTree(QueryPath, basePath, nav1);
		}

		public NavigationTree GetNavigationByPath(
			string path)
		{
			return GetNavigationByPath(path, path);
		}


		public HtmlString RenderBrowserTitle()
		{
			if (!string.IsNullOrEmpty(CustomBrowserTitle))
				return new HtmlString(CustomBrowserTitle);
			var s1 = SuppString.JoinNotEmpty(
				"{0}", " – ", Page.TitleShort, Node.TitleShort, Site.Title);
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

	}

}
