using Ans.Net6.Common.Services;

namespace Ans.Net6.Web
{

	public class LibOptions
	{
		public static readonly string Name
			= System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

		public MailerServiceOptions MailService { get; set; }
		public string SiteMapResetToken { get; set; }
		public bool Debug { get; set; }
	}

}
