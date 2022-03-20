using System;

namespace Ans.Net6.Web.Models
{

    public class ErrorViewModel
    {
        public Exception Exception { get; set; }
        public string RequestId { get; set; }
        public string ExceptionMessage { get; set; }
        public string OriginalPath { get; set; }
        public Uri RefererUri { get; set; }
        public int HttpCode { get; set; }
        public bool IsDebug { get; set; }

        public bool HasRequestId
            => !string.IsNullOrEmpty(RequestId);

        public bool HasExceptionMessage
            => !string.IsNullOrEmpty(ExceptionMessage);

        public bool HasOriginalPath
            => !string.IsNullOrEmpty(OriginalPath);

        public bool HasRefererUri
            => RefererUri != null;
    }

}
