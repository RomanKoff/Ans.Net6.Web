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
			Logger = logger;
			CurrentContext = currentContext;
			ViewRender = viewRender;
		}


		public IActionResult Index(
			string path)
		{
			CurrentContext.SetQueryPath(path);
			ViewEngineResult viewResult = ViewRender
				.GetViewEngineResult($"Nodes/{CurrentContext.QueryPath}");
			if (viewResult.View != null)
			{
				CurrentContext.SetViewPath(CurrentContext.QueryPath);
			}
			else
			{
				string path2 = $"{CurrentContext.QueryPath}/start";
				viewResult = ViewRender.GetViewEngineResult($"Nodes/{path2}");
				if (viewResult.View == null)
				{
					return NotFound();
				}
				CurrentContext.SetViewPath(path2);
			}
			CurrentNodeRelease();
			return View($"~/Views/Nodes/{CurrentContext.ViewPath}.cshtml");
		}


		public virtual void CurrentNodeRelease()
		{
		}

	}

}
