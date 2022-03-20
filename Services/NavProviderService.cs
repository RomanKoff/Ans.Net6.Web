using Ans.Net6.Common;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace Ans.Net6.Web.Services
{

	public interface INavProviderService
	{
		List<Nav> Navigator { get; }

		Nav GetItemByName(string name);
		Nav GetItemByPath(string path);
		void Refresh();
	}



	public class JsonNavProviderService
		: INavProviderService
	{
		private readonly IWebHostEnvironment _env;

		public List<Nav> Navigator { get; private set; }

		public JsonNavProviderService(
			IWebHostEnvironment env)
		{
			Debug.WriteLine("--- new JsonNavProviderService()");
			this._env = env;
			Refresh();
		}

		public Nav GetItemByName(
			string name)
		{
			return _scanByName(name, Navigator);
		}

		public Nav GetItemByPath(
			string path)
		{
			return _scanByPath(path, Navigator);
		}

		public void Refresh()
		{
			this.Navigator = SuppJson.GetObjectFromJsonFile<List<Nav>>(
				Path.Combine(_env.ContentRootPath, "_navs.json"));
		}

		// privates

		private Nav _scanByName(
			string name,
			List<Nav> branch)
		{
			foreach (var item1 in branch)
			{
				if (name == item1.Name)
					return item1;
				if (item1.HasSlaves)
				{
					var item2 = _scanByName(name, item1.Slaves);
					if (item2 != null)
						return item2;
				}
			}
			return null;
		}

		private Nav _scanByPath(
			string path,
			List<Nav> branch)
		{
			foreach (var item1 in branch)
			{
				if (path == item1.Path)
					return item1;
				if (item1.HasSlaves && path.StartsWith(item1.Path))
				{
					var item2 = _scanByPath(path[(item1.Path.Length)..], item1.Slaves);
					if (item2 != null)
						return item2;
				}
			}
			return null;
		}
	}

}
