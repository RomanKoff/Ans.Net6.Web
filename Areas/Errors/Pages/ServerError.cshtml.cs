using Ans.Net6.Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ans.Net6.Web.Areas.Errors.Pages
{

	public class ServerErrorModel
		: _ErrorPageModel_Base
	{
		public ServerErrorModel(
			ILogger<ServerErrorModel> logger,
			IConfiguration configuration)
			: base(logger, configuration)
		{
		}

		public void OnGet()
		{
			Init();
			Logger.LogError(
				"server500 | {0} | {1} | {2} | {3}",
				ViewModel.OriginalPath,
				ViewModel.RefererUri,
				ViewModel.RequestId,
				ViewModel.ExceptionMessage);
		}
	}

}
