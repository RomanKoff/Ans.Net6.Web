using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace Ans.Net6.Web.Services
{

	public interface IViewRenderService
	{
		ActionContext GetActionContext();
		ViewEngineResult GetViewEngineResult(ActionContext actionContext, string viewName);
		ViewEngineResult GetViewEngineResult(string viewName);
		Task<string> RenderToStringAsync(string viewName, object model);
	}



	public class ViewRenderService
		: IViewRenderService
	{

		private readonly IRazorViewEngine _razorViewEngine;
		private readonly ITempDataProvider _tempDataProvider;
		private readonly IServiceProvider _serviceProvider;


		public ViewRenderService(
			IRazorViewEngine razorViewEngine,
			ITempDataProvider tempDataProvider,
			IServiceProvider serviceProvider)
		{
			_razorViewEngine = razorViewEngine;
			_tempDataProvider = tempDataProvider;
			_serviceProvider = serviceProvider;
		}


		public ActionContext GetActionContext()
		{
			return new(
				new DefaultHttpContext { RequestServices = _serviceProvider },
				new RouteData(),
				new ActionDescriptor());
		}


		public ViewEngineResult GetViewEngineResult(
			ActionContext actionContext,
			string viewName)
		{
			return _razorViewEngine.FindView(actionContext, viewName, false);
		}


		public ViewEngineResult GetViewEngineResult(
			string viewName)
		{
			return GetViewEngineResult(GetActionContext(), viewName);
		}


		public async Task<string> RenderToStringAsync(
			string viewName,
			object model)
		{
			var actionContext = GetActionContext();
			var viewResult = GetViewEngineResult(actionContext, viewName);
			if (viewResult.View == null)
			{
				throw new ArgumentNullException($"{viewName} does not match any available view");
			}
			var viewDictionary = new ViewDataDictionary(
				new EmptyModelMetadataProvider(),
				new ModelStateDictionary())
			{
				Model = model
			};
			using var writer1 = new StringWriter();
			var viewContext = new ViewContext(
				actionContext,
				viewResult.View,
				viewDictionary,
				new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
				writer1,
				new HtmlHelperOptions()
			);
			await viewResult.View.RenderAsync(viewContext);
			return writer1.ToString();
		}

	}

}
