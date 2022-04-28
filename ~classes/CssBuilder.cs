namespace Ans.Net6.Web
{

	public class CssBuilder
		: List<string>
	{

		public CssBuilder()
		{
		}


		public CssBuilder(
			string cssClass)
			: this()
		{
			this.Add(cssClass);
		}


		public CssBuilder(
			bool flag,
			string cssClass)
			: this()
		{
			this.Add(flag, cssClass);
		}


		public new void Add(
			string cssClass)
		{
			if (!string.IsNullOrEmpty(cssClass))
				base.Add(cssClass);
		}


		public void Add(
			string template,
			params object[] args)
		{
			this.Add(string.Format(template, args));
		}


		public void Add(
			bool flag,
			string cssClass)
		{
			if (flag)
				this.Add(cssClass);
		}


		public void Add(
			bool flag,
			string template,
			params object[] args)
		{
			if (flag)
				this.Add(template, args);
		}


		public new void Insert(
			int index,
			string cssClass)
		{
			if (!string.IsNullOrEmpty(cssClass))
				base.Insert(index, cssClass);
		}


		public void Insert(
			int index,
			string template,
			params object[] args)
		{
			this.Insert(index, string.Format(template, args));
		}


		public void Insert(
			bool flag,
			int index,
			string cssClass)
		{
			if (flag)
				this.Insert(index, cssClass);
		}


		public void Insert(
			bool flag,
			int index,
			string template,
			params object[] args)
		{
			if (flag)
				this.Insert(index, template, args);
		}


		public override string ToString()
		{
			return (Count > 0)
				? string.Join(" ", this) : string.Empty;
		}

	}

}
