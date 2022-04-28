using Ans.Net6.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;

namespace Ans.Net6.Web.Nodes
{

	public class _NodesController_Base
		: Controller
	{

		public ILogger<_NodesController_Base> Logger { get; private set; }
		public ICurrentContext CurrentContext { get; private set; }
		public IViewRenderService ViewRender { get; private set; }


		public _NodesController_Base(
			ILogger<_NodesController_Base> logger,
			ICurrentContext currentContext,
			IViewRenderService viewRender)
		{
			System.Diagnostics.Debug.WriteLine("--- new _NodesController_Base()");
			Logger = logger;
			CurrentContext = currentContext;
			ViewRender = viewRender;
		}


		public IActionResult Index(
			string path)
		{
			System.Diagnostics.Debug.WriteLine($"--- Index({path})");
			CurrentContext.SetQueryPath(path);
			ViewEngineResult engine1 = ViewRender
				.GetViewEngineResult($"Nodes/{CurrentContext.FixQueryPath}");
			if (engine1.View != null)
			{
				CurrentContext.SetViewPath(CurrentContext.FixQueryPath);
			}
			else
			{
				string path2 = $"{CurrentContext.FixQueryPath}/start";
				engine1 = ViewRender.GetViewEngineResult($"Nodes/{path2}");
				if (engine1.View == null)
				{
					return NotFound();
				}
				CurrentContext.SetViewPath(path2);
			}
			CurrentContext.QueryRelease();
			CurrentRelease();
			return View($"~/Views/Nodes/{CurrentContext.ViewPath}.cshtml");
		}


		public IActionResult SiteMap_Refresh(
			string token)
		{
			System.Diagnostics.Debug.WriteLine($"--- SiteMap_Reset({token})");
			if (token != CurrentContext.Options.SiteMapResetToken)
				return NotFound();
			CurrentContext.SiteMapRefresh();
			return Content("SiteMap Refresh - OK");
		}


		public virtual void CurrentRelease()
		{
		}

	}

}
