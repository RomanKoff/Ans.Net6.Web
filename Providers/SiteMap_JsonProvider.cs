using Ans.Net6.Common;
using Microsoft.AspNetCore.Hosting;

namespace Ans.Net6.Web.Providers
{

	public class SiteMap_JsonProvider
		: __SiteMapProvider_Proto,
		ISiteMapProvider
	{
		private readonly IWebHostEnvironment _env;

		public SiteMap_JsonProvider(
			IWebHostEnvironment env)
		{
			System.Diagnostics.Debug.WriteLine("--- new SiteMap_JsonProvider()");
			this._env = env;
			Refresh();
		}

		public override void Refresh()
		{
			System.Diagnostics.Debug.WriteLine("--- SiteMapProvider.Refresh()");
			this.Items = SuppJson.GetObjectFromJsonFile<SiteMapData>(
				Path.Combine(_env.ContentRootPath, "sitemap.json"))
					.Items;
			Compile();
		}
	}

}
