using System.Collections.Generic;

namespace Ans.Net6.Web
{

	public static partial class _Const
	{

		public static readonly ContentInfo CONTENTINFO_BIN = new(
			"*", "application/octet-stream", ContentClassesEnum.Bin, false, false);

		public static readonly List<ContentInfo> CONTENTINFOS = new()
		{
			// Arcive
			new(".gtar", "application/x-gtar", ContentClassesEnum.Archive, false, false),
			new(".gz", "application/x-gzip", ContentClassesEnum.Archive, false, false),
			new(".tar", "application/x-tar", ContentClassesEnum.Archive, false, false),
			new(".tgz", "application/x-compressed", ContentClassesEnum.Archive, false, false),
			new(".z", "application/x-compress", ContentClassesEnum.Archive, false, false),
			new(".z", "application/x-compress", ContentClassesEnum.Archive, false, false),
			new(".zip", "application/zip", ContentClassesEnum.Archive, false, false),

			// Audio                           
			new(".aif", "audio/x-aiff", ContentClassesEnum.Audio, false, false),
			new(".aifc", "audio/x-aiff", ContentClassesEnum.Audio, false, false),
			new(".aiff", "audio/x-aiff", ContentClassesEnum.Audio, false, false),
			new(".au", "audio/basic", ContentClassesEnum.Audio, false, false),
			new(".m3u", "audio/x-mpegurl", ContentClassesEnum.Audio, false, false),
			new(".mid", "audio/mid", ContentClassesEnum.Audio, false, false),
			new(".mp3", "audio/mpeg", ContentClassesEnum.Audio, false, false),
			new(".ogg", "audio/ogg", ContentClassesEnum.Audio, false, false),
			new(".ra", "audio/x-pn-realaudio", ContentClassesEnum.Audio, false, false),
			new(".ram", "audio/x-pn-realaudio", ContentClassesEnum.Audio, false, false),
			new(".rmi", "audio/mid", ContentClassesEnum.Audio, false, false),
			new(".snd", "audio/basic", ContentClassesEnum.Audio, false, false),
			new(".wav", "audio/x-wav", ContentClassesEnum.Audio, false, false),

			// Document
			new(".ai", "application/postscript", ContentClassesEnum.Document, false, false),
			new(".doc", "application/msword", ContentClassesEnum.Document, false, false),
			new(".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", ContentClassesEnum.Document, false, false),
			new(".dot", "application/msword", ContentClassesEnum.Document, false, false),
			new(".dotx", "application/msword", ContentClassesEnum.Document, false, false),
			new(".dvi", "application/x-dvi", ContentClassesEnum.Document, false, false),
			new(".eps", "application/postscript", ContentClassesEnum.Document, false, false),
			new(".hlp", "application/winhlp", ContentClassesEnum.Document, false, false),
			new(".latex", "application/x-latex", ContentClassesEnum.Document, false, false),
			new(".mdb", "application/x-msaccess", ContentClassesEnum.Document, false, false),
			new(".mpp", "application/vnd.ms-project", ContentClassesEnum.Document, false, false),
			new(".pdf", "application/pdf", ContentClassesEnum.Document, false, false),
			new(".pot", "application/vnd.ms-powerpoint", ContentClassesEnum.Document, false, false),
			new(".pps", "application/vnd.ms-powerpoint", ContentClassesEnum.Document, false, false),
			new(".ppt", "application/vnd.ms-powerpoint", ContentClassesEnum.Document, false, false),
			new(".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", ContentClassesEnum.Document, false, false),
			new(".ps", "application/postscript", ContentClassesEnum.Document, false, false),
			new(".pub", "application/x-mspublisher", ContentClassesEnum.Document, false, false),
			new(".rtf", "application/rtf", ContentClassesEnum.Document, false, false),
			new(".tex", "application/x-tex", ContentClassesEnum.Document, false, false),
			new(".wcm", "application/vnd.ms-works", ContentClassesEnum.Document, false, false),
			new(".wdb", "application/vnd.ms-works", ContentClassesEnum.Document, false, false),
			new(".wks", "application/vnd.ms-works", ContentClassesEnum.Document, false, false),
			new(".wps", "application/vnd.ms-works", ContentClassesEnum.Document, false, false),
			new(".wri", "application/x-mswrite", ContentClassesEnum.Document, false, false),
			new(".xla", "application/vnd.ms-excel", ContentClassesEnum.Document, false, false),
			new(".xlc", "application/vnd.ms-excel", ContentClassesEnum.Document, false, false),
			new(".xlm", "application/vnd.ms-excel", ContentClassesEnum.Document, false, false),
			new(".xls", "application/vnd.ms-excel", ContentClassesEnum.Document, false, false),
			new(".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", ContentClassesEnum.Document, false, false),
			new(".xlt", "application/vnd.ms-excel", ContentClassesEnum.Document, false, false),
			new(".xlw", "application/vnd.ms-excel", ContentClassesEnum.Document, false, false),

			// Image                           
			new(".bmp", "image/bmp", ContentClassesEnum.Image, true, true),
			new(".cmx", "image/x-cmx", ContentClassesEnum.Image, false, false),
			new(".cod", "image/cis-cod", ContentClassesEnum.Image, false, false),
			new(".gif", "image/gif", ContentClassesEnum.Image, true, false),
			new(".ico", "image/x-icon", ContentClassesEnum.Image, false, false),
			new(".ief", "image/ief", ContentClassesEnum.Image, false, false),
			new(".jfif", "image/pipeg", ContentClassesEnum.Image, false, false),
			new(".jpe", "image/jpeg", ContentClassesEnum.Image, true, true),
			new(".jpeg", "image/jpeg", ContentClassesEnum.Image, true, true),
			new(".jpg", "image/jpeg", ContentClassesEnum.Image, true, true),
			new(".pbm", "image/x-portable-bitmap", ContentClassesEnum.Image, false, false),
			new(".pgm", "image/x-portable-graymap", ContentClassesEnum.Image, false, false),
			new(".png", "image/png", ContentClassesEnum.Image, true, false),
			new(".pnm", "image/x-portable-anymap", ContentClassesEnum.Image, false, false),
			new(".ppm", "image/x-portable-pixmap", ContentClassesEnum.Image, false, false),
			new(".ras", "image/x-cmu-raster", ContentClassesEnum.Image, false, false),
			new(".rgb", "image/x-rgb", ContentClassesEnum.Image, false, false),
			new(".svg", "images/svg+xml", ContentClassesEnum.Image, false, false),
			new(".svgz", "images/svg+xml", ContentClassesEnum.Image, false, false),
			new(".tif", "image/tiff", ContentClassesEnum.Image, false, false),
			new(".tiff", "image/tiff", ContentClassesEnum.Image, false, false),
			new(".xbm", "image/x-xbitmap", ContentClassesEnum.Image, false, false),
			new(".xpm", "image/x-xpixmap", ContentClassesEnum.Image, false, false),
			new(".xwd", "image/x-xwindowdump", ContentClassesEnum.Image, false, false),

			// Text                            
			new(".323", "text/h323", ContentClassesEnum.Text, false, false),
			new(".bas", "text/plain", ContentClassesEnum.Text, false, false),
			new(".c", "text/plain", ContentClassesEnum.Text, false, false),
			new(".css", "text/css", ContentClassesEnum.Text, false, false),
			new(".csv", "text/csv", ContentClassesEnum.Text, false, false),
			new(".etx", "text/x-setext", ContentClassesEnum.Text, false, false),
			new(".h", "text/plain", ContentClassesEnum.Text, false, false),
			new(".htc", "text/x-component", ContentClassesEnum.Text, false, false),
			new(".htm", "text/html", ContentClassesEnum.Text, false, false),
			new(".html", "text/html", ContentClassesEnum.Text, false, false),
			new(".htt", "text/webviewhtml", ContentClassesEnum.Text, false, false),
			new(".js", "text/javascript", ContentClassesEnum.Text, false, false),
			new(".json", "application/json", ContentClassesEnum.Text, false, false),
			new(".less", "text/css", ContentClassesEnum.Text, false, false),
			new(".rss", "application/rss+xml;charset=UTF-8", ContentClassesEnum.Text, false, false),
			new(".rtx", "text/richtext", ContentClassesEnum.Text, false, false),
			new(".sct", "text/scriptlet", ContentClassesEnum.Text, false, false),
			new(".shtml", "text/html", ContentClassesEnum.Text, false, false),
			new(".stm", "text/html", ContentClassesEnum.Text, false, false),
			new(".tsv", "text/tab-separated-values", ContentClassesEnum.Text, false, false),
			new(".txt", "text/plain", ContentClassesEnum.Text, false, false),
			new(".uls", "text/iuls", ContentClassesEnum.Text, false, false),
			new(".vcf", "text/x-vcard", ContentClassesEnum.Text, false, false),
			new(".xml", "application/xml;charset=UTF-8", ContentClassesEnum.Text, false, false),

			// Video                           
			new(".asf", "video/x-ms-asf", ContentClassesEnum.Video, false, false),
			new(".asr", "video/x-ms-asf", ContentClassesEnum.Video, false, false),
			new(".asx", "video/x-ms-asf", ContentClassesEnum.Video, false, false),
			new(".avi", "video/x-msvideo", ContentClassesEnum.Video, false, false),
			new(".f4v", "video/mp4", ContentClassesEnum.Video, false, false),
			new(".flv", "video/x-flv", ContentClassesEnum.Video, false, false),
			new(".lsf", "video/x-la-asf", ContentClassesEnum.Video, false, false),
			new(".lsx", "video/x-la-asf", ContentClassesEnum.Video, false, false),
			new(".mov", "video/quicktime", ContentClassesEnum.Video, false, false),
			new(".movie", "video/x-sgi-movie", ContentClassesEnum.Video, false, false),
			new(".mp2", "video/mpeg", ContentClassesEnum.Video, false, false),
			new(".mp4", "video/mp4", ContentClassesEnum.Video, false, false),
			new(".mpa", "video/mpeg", ContentClassesEnum.Video, false, false),
			new(".mpe", "video/mpeg", ContentClassesEnum.Video, false, false),
			new(".mpeg", "video/mpeg", ContentClassesEnum.Video, false, false),
			new(".mpg", "video/mpeg", ContentClassesEnum.Video, false, false),
			new(".mpv2", "video/mpeg", ContentClassesEnum.Video, false, false),
			new(".ogv", "video/ogg", ContentClassesEnum.Video, false, false),
			new(".qt", "video/quicktime", ContentClassesEnum.Video, false, false),
			new(".webm", "video/webm", ContentClassesEnum.Video, false, false),
		};

	}

}
