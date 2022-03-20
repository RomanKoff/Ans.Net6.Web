using System;

namespace Ans.Net6.Web
{

	public static class SuppContentInfo
	{

		public static ContentInfo GetContentInfo(
			string extention)
		{
			return _Const.CONTENTINFOS
				.Find(x => x.Extention.Equals(
					extention, StringComparison.InvariantCultureIgnoreCase))
						?? _Const.CONTENTINFO_BIN;
		}


		public static string GetFileCssClass(
			string extention,
			string contentClass)
		{
			return extention switch
			{
				".xls" or
				".xlsx"
					=> "file-xls",
				".ppt" or
				".pptx"
					=> "file-ppt",
				".doc" or
				".docx" or
				".dot" or
				".dotx"
					=> "file-doc",
				".pdf"
					=> "file-pdf",
				".7z" or
				".gz" or
				".gzip" or
				".rar" or
				".zip"
					=> "file-archive",
				".txt"
					=> "file-txt",
				".bat" or
				".cmd" or
				".cs" or
				".css" or
				".htm" or
				".html" or
				".vb" or
				".vba"
					=> "file-code",
				".bmp" or
				".gif" or
				".jpeg" or
				".jpg" or
				".png" or
				".psd"
					=> "file-image",
				".mid" or
				".midi" or
				".mp3" or
				".wav" or
				".wma"
					=> "file-audio",
				".avi" or
				".mp4" or
				".mpeg" or
				".mpg" or
				".wmv"
					=> "file-video",
				_ => contentClass switch
				{
					"Archive"
						=> "file-archive",
					"Audio"
						=> "file-audio",
					"Text" or
					"Document"
						=> "file-document",
					"Image"
						=> "file-image",
					"Video"
						=> "file-video",
					"Code"
						=> "file-code",
					_ => "file",
				},
			};
		}

	}

}
