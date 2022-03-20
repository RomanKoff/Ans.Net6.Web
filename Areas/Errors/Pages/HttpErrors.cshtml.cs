using Ans.Net6.Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ans.Net6.Web.Areas.Errors.Pages
{

	public class HttpErrorsModel
		: _ErrorPageModel_Base
	{
		public HttpErrorsModel(
			ILogger<HttpErrorsModel> logger,
			IConfiguration configuration)
			: base(logger, configuration)
		{
		}

		public void OnGet(
			int code)
		{
			Init();
			ViewModel.HttpCode = code;
			Logger.LogError(
				"http-{0} | {1} | {2} | {3} | {4}",
				ViewModel.HttpCode,
				ViewModel.OriginalPath,
				ViewModel.RefererUri,
				ViewModel.RequestId,
				ViewModel.ExceptionMessage);
		}
	}

}
