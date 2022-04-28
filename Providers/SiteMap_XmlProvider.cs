using Ans.Net6.Common;
using Microsoft.AspNetCore.Hosting;

namespace Ans.Net6.Web.Providers
{

	public class SiteMap_XmlProvider
		: __SiteMapProvider_Proto,
		ISiteMapProvider
	{
		private readonly IWebHostEnvironment _env;

		public SiteMap_XmlProvider(
			IWebHostEnvironment env)
		{
			System.Diagnostics.Debug.WriteLine("--- new SiteMap_XmlProvider()");
			this._env = env;
			Refresh();
		}

		public override void Refresh()
		{
			System.Diagnostics.Debug.WriteLine("--- SiteMapProvider.Refresh()");
			this.Items = SuppXml.GetObjectFromXmlFile<SiteMapData>(
				Path.Combine(_env.ContentRootPath, "sitemap.xml"),
				"Ans.Net6.Web.Sitemap.xsd")
					.Items;
			Compile();
		}
	}

}
