﻿namespace Ans.Net6.Web
{

	public class NavigationTree
	{
		public List<NavigationItem> Items { get; private set; }

		public NavigationTree(
			string currentPath,
			string basePath,
			Nav navItem)
		{
			this.Items = new List<NavigationItem>();
			_scan(FixPath(currentPath), navItem, Items, basePath);
		}

		public static string FixPath(
			string path)
		{
			return (path ?? "").EndsWith("/start")
				? path[..(path.Length - 5)] : path;
		}

		private void _scan(
			string currentPath,
			Nav navItem,
			List<NavigationItem> items,
			string pathPrefix)
		{
			if (navItem != null && navItem.Slaves != null)
				foreach (var nav1 in navItem.Slaves)
				{
					string s1 = pathPrefix + nav1.Path;
					var item1 = new NavigationItem
					{
						Href = nav1.Url ?? s1,
						IsBlank = nav1.Url != null,
						InnerHtml = nav1.Title,
					};
					item1.IsActive = item1.Href.Equals(currentPath);
					item1.IsSubActive = currentPath.StartsWith(item1.Href);
					items.Add(item1);
					if (nav1.HasSlaves)
					{
						item1.Items = new List<NavigationItem>();
						_scan(currentPath, nav1, item1.Items, s1);
					}
				}
		}
	}



	public class NavigationItem
	{
		public List<NavigationItem> Items { get; set; }

		public string Id { get; set; }
		public string Class { get; set; }
		public string Href { get; set; }
		public string InnerHtml { get; set; }
		public bool IsActive { get; set; }
		public bool IsSubActive { get; set; }
		public bool IsBlank { get; set; }
		public bool IsDisabled { get; set; }

		public NavigationItem()
		{
		}

		public bool HasItems
			=> Items != null && Items.Any();

	}

}
