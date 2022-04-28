using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Ans.Net6.Web
{

	public interface ISiteMapData
	{
		List<SiteMapItem> Items { get; set; }
	}



	[XmlRoot("data")]
	public class SiteMapData
		: ISiteMapData
	{
		[XmlElement("item")]
		[JsonProperty("items")]
		public List<SiteMapItem> Items { get; set; }
	}



	public class SiteMapItem
	{

		/// <summary>
		/// Сериализация.
		///		1. "название";
		///		2. "адрес|название";
		///		3. "адрес|название|{ShortTitle}".
		///			название = "['#'|'-']{Title}"
		///			адрес = "{Name}|'^'{ExternalUrl}"
		///				'^' - признак внешней ссылки
		///				'#' - признак группы
		///				'-' - признак заглушки
		/// </summary>
		[XmlAttribute("def")]
		[JsonProperty("def")]
		public string Def { get; set; }

		/// <summary>
		/// Имя узла
		/// </summary>
		[XmlAttribute("name")]
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Основное название узла
		/// </summary>
		[XmlAttribute("title")]
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Короткое название узла (->Title)
		/// </summary>
		[XmlAttribute("short")]
		[JsonProperty("short")]
		public string ShortTitle { get => _shortTitle ?? Title; set => _shortTitle = value; }
		private string _shortTitle;

		/// <summary>
		/// Ссылка на внешний ресурс (перекрывает Name)
		/// </summary>
		[XmlAttribute("url")]
		[JsonProperty("url")]
		public string ExternalUrl { get; set; }

		/// <summary>
		/// Дополнительная информация
		/// </summary>
		[XmlAttribute("info")]
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// Свойства
		/// </summary>
		[XmlAttribute("props")]
		[JsonProperty("props")]
		public string Props { get; set; }

		/// <summary>
		/// Теги
		/// </summary>
		[XmlAttribute("tags")]
		[JsonProperty("tags")]
		public string Tags { get; set; }

		/// <summary>
		/// Это группа узлов (перекрывает IsPlug. Name или ExternalUrl игнорируются)
		/// </summary>
		[XmlAttribute("group")]
		[JsonProperty("group")]
		public bool IsGroup { get; set; }

		/// <summary>
		/// Это заглушка (Name или ExternalUrl игнорируются)
		/// </summary>
		[XmlAttribute("plug")]
		[JsonProperty("plug")]
		public bool IsPlug { get; set; }

		/// <summary>
		/// Отключено (узел и его подчиненные узлы игнорируются)
		/// </summary>
		[XmlAttribute("disabled")]
		[JsonProperty("disabled")]
		public bool IsDisabled { get; set; }

		/// <summary>
		/// Подчиненные узлы
		/// </summary>
		[XmlElement("item")]
		[JsonProperty("items")]
		public List<SiteMapItem> Items { get; set; }


		/// <summary>
		/// Верхние узлы (собираются после компиляции)
		/// </summary>
		[NotMapped]
		[JsonIgnore]
		[XmlIgnore]
		public List<SiteMapItem> Masters { get; set; }

		/// <summary>
		/// Указана ссылка на внешний ресурс (ссылка открывается в новом окне)
		/// </summary>
		[NotMapped]
		[JsonIgnore]
		[XmlIgnore]
		public bool IsExternal
			=> !string.IsNullOrEmpty(ExternalUrl);

		/// <summary>
		/// Наличие короткого названия узла
		/// </summary>
		[NotMapped]
		[JsonIgnore]
		[XmlIgnore]
		public bool HasShortTitle
			=> !string.IsNullOrEmpty(_shortTitle);

		/// <summary>
		/// Наличие верхних узлов
		/// </summary>
		[NotMapped]
		[JsonIgnore]
		[XmlIgnore]
		public bool HasMasters
			=> Masters != null && Masters.Any();

		/// <summary>
		/// Наличие подчиненныч узлов
		/// </summary>
		[NotMapped]
		[JsonIgnore]
		[XmlIgnore]
		public bool HasItems
			=> Items != null && Items.Any();


		/// <summary>
		/// Десериализация Def
		/// </summary>
		public void ParseDef()
		{
			if (!string.IsNullOrEmpty(Def))
			{
				var a1 = Def.Split('|');
				switch (a1.Length)
				{
					case 2:
						_parse1(a1[0]);
						Title = a1[1];
						break;
					case 3:
						_parse1(a1[0]);
						ShortTitle = a1[1];
						Title = a1[2];
						break;
					default:
						_parse2(a1[0]);
						break;
				}
			}
		}


		// privates

		private void _parse1(
			string value)
		{
			if (!string.IsNullOrEmpty(value))
				if (value[0] == '^')
					ExternalUrl = value[1..];
				else
					Name = value;
		}

		private void _parse2(
			string value)
		{
			if (!string.IsNullOrEmpty(value))
				switch (value[0])
				{
					case '#':
						Title = value[1..];
						IsGroup = true;
						break;
					case '-':
						Title = value[1..];
						IsPlug = true;
						break;
					default:
						Title = value;
						break;
				}
		}

	}

}
