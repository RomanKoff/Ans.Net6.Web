using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Ans.Net6.Web
{

	public static partial class _e
	{

		public static string GetViewName(
			this IView view)
		{
			string s1 = view.Path;
			return Path.GetFileNameWithoutExtension(
				s1[s1.LastIndexOf('/')..]);
		}


		public static string GetViewName(
			this IRazorPage view)
		{
			string s1 = view.Path;
			return Path.GetFileNameWithoutExtension(
				s1[s1.LastIndexOf('/')..]);
		}	

	}

}
