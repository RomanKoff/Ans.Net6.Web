using Ans.Net6.Web.Nodes;
using Ans.Net6.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Ans.Net6.Web
{

	public static partial class LibStartup
	{

		public static IServiceCollection AddAnsServices(
			this IServiceCollection services)
		{
			_ = services.AddHttpContextAccessor();
			_ = services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
			_ = services.AddScoped<IViewRenderService, ViewRenderService>();
			_ = services.AddScoped(
				x => x.GetRequiredService<IUrlHelperFactory>().GetUrlHelper(
					x.GetRequiredService<IActionContextAccessor>().ActionContext));
			_ = services.AddScoped<ISiteContext, SiteContext>();
			_ = services.AddScoped<INodeContext, NodeContext>();
			_ = services.AddScoped<IPageContext, PageContext>();
			_ = services.AddScoped<ICurrentContext, CurrentContext>();
			return services;
		}


		public static IApplicationBuilder UseAnsErrors(
			this IApplicationBuilder app)
		{
			_ = app.UseExceptionHandler("/Errors/ServerError");
			_ = app.UseStatusCodePagesWithReExecute("/Errors/HttpErrors", "?code={0}");
			return app;
		}

		public static IApplicationBuilder UseAnsNodes(
			this IApplicationBuilder app)
		{
			_ = app.UseEndpoints(o =>
			  {
				  o.MapControllerRoute("System_SiteMap_Refresh", "system/sitemap/refresh",
					  new { controller = "Nodes", action = "SiteMap_Refresh" });
				  o.MapControllerRoute("Nodes", "{*path}",
					  new { controller = "Nodes", action = "Index", path = "start" });
			  });
			return app;
		}


	}

}
