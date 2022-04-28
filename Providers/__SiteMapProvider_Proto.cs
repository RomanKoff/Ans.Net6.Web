namespace Ans.Net6.Web.Providers
{

	public interface ISiteMapProvider
		: ISiteMapData
	{
		List<SiteMapItem> AllItems { get; }

		SiteMapItem GetByName(string name);

		void Refresh();
	}



	public abstract class __SiteMapProvider_Proto
		: SiteMapData,
		ISiteMapProvider
	{

		public List<SiteMapItem> AllItems { get; internal set; }


		public virtual SiteMapItem GetByName(
			string name)
		{
			if (string.IsNullOrEmpty(name))
				return null;
			return AllItems.FirstOrDefault(
				x => x.Name == name);
		}


		internal virtual void ScanItems(
			List<SiteMapItem> items,
			SiteMapItem master)
		{
			foreach (var item1 in items)
			{
				item1.ParseDef();
				if (!item1.IsDisabled)
				{
					this.AllItems.Add(item1);
					if (master != null && !master.IsGroup)
					{
						item1.Masters = new List<SiteMapItem>();
						if (master.HasMasters)
							item1.Masters.AddRange(master.Masters);
						item1.Masters.Add(master);
					}
					if (item1.HasItems)
						ScanItems(item1.Items, item1);
				}
			}
		}


		internal virtual void Compile()
		{
			this.AllItems = new List<SiteMapItem>();
			ScanItems(Items, null);
		}


		public abstract void Refresh();

	}

}
