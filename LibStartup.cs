using Ans.Net6.Web.Nodes;
using Ans.Net6.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Ans.Net6.Web
{

	public static partial class LibStartup
	{

		public static IServiceCollection AddAnsNet6Web(
			this IServiceCollection services)
		{
			return services
				.AddHttpContextAccessor()
				.AddSingleton<IActionContextAccessor, ActionContextAccessor>()
				.AddScoped<IViewRenderService, ViewRenderService>()
				.AddScoped(x => x.GetRequiredService<IUrlHelperFactory>()
					.GetUrlHelper(x.GetRequiredService<IActionContextAccessor>()
						.ActionContext))
				.AddScoped<ISiteContext, SiteContext>()
				.AddScoped<INodeContext, NodeContext>()
				.AddScoped<IPageContext, PageContext>()
				.AddScoped<ICurrentContext, CurrentContext>();
		}


		public static IApplicationBuilder UseAnsNet6WebErrors(
			this IApplicationBuilder app)
		{
			app.UseExceptionHandler("/Errors/ServerError");
			app.UseStatusCodePagesWithReExecute("/Errors/HttpErrors", "?code={0}");
			return app;
		}

	}

}
