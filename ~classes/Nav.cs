﻿using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Ans.Net6.Web
{

	public class Nav
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public string Desc { get; set; }
		public string Path { get; set; }
		public string Url { get; set; }
		public string Img { get; set; }
		public string Type { get; set; }
		public string Mode { get; set; }
		public string Class { get; set; }
		public string Attribs { get; set; }
		public string Tags { get; set; }
		public int Ord { get; set; }
		public bool Active { get; set; }
		public bool External { get; set; }
		public bool Disabled { get; set; }
		public bool Hidden { get; set; }
		public string Value { get; set; }
		public int VInt { get; set; }
		public long VLong { get; set; }
		public double VDouble { get; set; }
		public float VFloat { get; set; }
		public decimal VDecimal { get; set; }
		public DateTime VDateTime { get; set; }
		public bool VBool { get; set; }

		public string ShortTitle
		{
			get => _shortTitle ?? Title;
			set => _shortTitle = value;
		}
		private string _shortTitle;

		public List<Nav> Slaves { get; set; }

		[JsonIgnore, XmlIgnore]
		public bool HasSlaves
			=> Slaves != null && Slaves.Any();

		public Nav()
		{
		}

		public Nav(
			string title)
		{
			this.Title = title;
		}

		public Nav(
			string url,
			string title)
			: this(title)
		{
			this.Url = url;
		}

		public Nav(
			string url,
			string shortTitle,
			string title)
			: this(url, title)
		{
			this.ShortTitle = shortTitle;
		}

		//public void ParseTarget(
		//	string target)
		//{
		//	bool f1 = target.StartsWith('^');
		//	bool f2 = f1 || target.StartsWith("http:") || target.StartsWith("https:");
		//	if (f2)
		//	{
		//		Path = null;
		//		ExternalUrl = (f1) ? target[1..] : target;
		//	}
		//	else
		//	{
		//		Path = target;
		//	}
		//}

		//public void ParseFace(
		//	string face)
		//{
		//	var a1 = face.Split("|");
		//	Title = a1[0];
		//	if (a1.Length > 1)
		//	{
		//		ImageUrl = a1[1];
		//		if (a1.Length > 2)
		//		{
		//			Description = a1[2];
		//		}
		//	}
		//}
	}

}
