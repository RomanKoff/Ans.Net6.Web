# Ans.Net6.Common.Nodes


#### Contexts

```CSharp

// Razor: @Current
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


// Razor: @Site, @Current.Site
public interface ISiteContext
{
	//string Title { get; set; }
	//string TitleShort { get; set; }
	//string Container { get; set; }
	//List<NavigationItem> Breadcrumb { get; set; }
	//bool HideBreadcrumb { get; set; }
	//bool AllowBreadcrumb { get; }
	//void InsertToBreadcrumb(NavigationItem link);

	string HomeUrl { get; set; }
	string HeaderCssClass { get; set; }
	string FooterCssClass { get; set; }
	void InsertToBreadcrumb();
}


// Razor: @Node, @Current.Node
public interface INodeContext
{
	//string Title { get; set; }
	//string TitleShort { get; set; }
	//string Container { get; set; }
	//List<NavigationItem> Breadcrumb { get; set; }
	//bool HideBreadcrumb { get; set; }
	//bool AllowBreadcrumb { get; }
	//void InsertToBreadcrumb(NavigationItem link);

	string Name { get; set; }
	string ParentTitle { get; set; }
	string ParentUrl { get; set; }
	string HeaderCssClass { get; set; }
	string FooterCssClass { get; set; }
	bool HideHeader { get; set; }
	bool HideFooter { get; set; }
	bool HideParent { get; set; }
	bool AllowFooter { get; }
	bool AllowHeader { get; }
	bool AllowParent { get; }
}


// Razor: @Page, @Current.Page
public interface IPageContext
{
	//string Title { get; set; }
	//string TitleShort { get; set; }
	//string Container { get; set; }
	//List<NavigationItem> Breadcrumb { get; set; }
	//bool HideBreadcrumb { get; set; }
	//bool AllowBreadcrumb { get; }
	//void InsertToBreadcrumb(NavigationItem link);

	string MetaDescription { get; set; }
	string MetaKeywords { get; set; }
	bool OffContainer { get; set; }
	string BreadcrumbCssClass { get; set; }
	void InsertToBreadcrumb(string title);
	void InsertToBreadcrumb();
}

```


#### Controllers

```CSharp

public class _NodesController_Base : Controller
{
	ILogger<_NodesController_Base> Logger { get; }
	ICurrentContext CurrentContext { get; }
	IViewRenderService ViewRender { get; }

	_NodesController_Base(
		ILogger<_NodesController_Base> logger,
		ICurrentContext currentContext,
		IViewRenderService viewRender);

	IActionResult Index(
		string path);

	virtual void CurrentNodeRelease();
}

```


#### ViewImports

```CSharp

@using Ans.Net6.Common
@using Ans.Net6.Web
@using Ans.Net6.Web.Nodes
@using Ans.Net6.Web.Services
@using System.Text
@using Microsoft.AspNetCore.Html
@inject ISiteContext Site
@inject INodeContext Node
@inject IPageContext Page
@inject ICurrentContext Current
@inject INavProviderService NavProvider
@addTagHelper "*, Microsoft.AspNetCore.Mvc.TagHelpers"
@addTagHelper "*, Ans.Net6.Web"

```