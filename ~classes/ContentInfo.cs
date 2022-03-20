using System.Net.Http.Headers;

namespace Ans.Net6.Web
{

	public enum ContentClassesEnum
	{
		Archive,
		Audio,
		Bin,
		Code,
		Document,
		Image,
		Text,
		Video
	}



	public class ContentInfo
	{
		public string Extention { get; set; }
		public string ContentType { get; set; }
		public ContentClassesEnum ContentClass { get; set; }
		public bool IsImage { get; set; }
		public bool IsJpeg { get; set; }

		public ContentInfo()
		{
		}

		public ContentInfo(
			string extention,
			string contentType,
			ContentClassesEnum contentClass,
			bool isImage,
			bool isJpeg)
			: this()
		{
			this.Extention = extention;
			this.ContentType = contentType;
			this.ContentClass = contentClass;
			this.IsImage = isImage;
			this.IsJpeg = isJpeg;
		}

		public MediaTypeHeaderValue GetMediaTypeHeaderValue()
		{
			return new MediaTypeHeaderValue(ContentType);
		}
	}	

}
