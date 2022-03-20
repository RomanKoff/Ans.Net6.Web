using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Ans.Net6.Web.Models
{

    public interface IErrorPageModel
    {
        ErrorViewModel ViewModel { get; set; }
        void Init();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class _ErrorPageModel_Base
        : PageModel, IErrorPageModel
    {
        private readonly IConfiguration _configuration;

        public readonly ILogger<_ErrorPageModel_Base> Logger;
        public readonly LibOptions Options;
        public ErrorViewModel ViewModel { get; set; }

        public _ErrorPageModel_Base(
            ILogger<_ErrorPageModel_Base> logger,
            IConfiguration configuration)
        {
            _configuration = configuration;
            Logger = logger;
            Options = _configuration
                .GetSection(LibOptions.Name)
                .Get<LibOptions>();
        }

        public virtual void Init()
        {
            this.ViewModel = new ErrorViewModel();
            var f1 = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            var f2 = HttpContext.Features.Get<IExceptionHandlerFeature>();
            ViewModel.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            ViewModel.RefererUri = Request.GetTypedHeaders().Referer;
            ViewModel.OriginalPath = f1?.OriginalPath;
            ViewModel.Exception = f2?.Error;
            ViewModel.ExceptionMessage = f2?.Error.Message;
            ViewModel.IsDebug = !(Options == null || !Options.Debug);
        }
    }

}
