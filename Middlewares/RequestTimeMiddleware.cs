using Microsoft.AspNetCore.Http;

namespace Ans.Net6.Web.Middlewares
{

	//	var httpRequestTimeFeature = HttpContext.Features.Get<IHttpRequestTimeFeature>();
	//	if (httpRequestTimeFeature != null)
	//	{
	//		var requestTime = httpRequestTimeFeature.RequestTime;
	//	}



	public interface IHttpRequestTimeFeature
	{
		DateTime RequestTime { get; }
	}



	public class HttpRequestTimeFeature
		: IHttpRequestTimeFeature
	{
		public DateTime RequestTime { get; }

		public HttpRequestTimeFeature()
		{
			RequestTime = DateTime.Now;
		}
	}



	public class RequestTimeMiddleware
	{
		private readonly RequestDelegate _next;

		public RequestTimeMiddleware(
			RequestDelegate next)
		{
			_next = next;
		}

		public Task InvokeAsync(
			HttpContext context)
		{
			var httpRequestTimeFeature = new HttpRequestTimeFeature();
			context.Features.Set<IHttpRequestTimeFeature>(httpRequestTimeFeature);
			return this._next(context);
		}
	}

}
