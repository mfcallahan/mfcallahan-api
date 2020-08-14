using System;
using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.Models.ApiResponses
{
    [ExcludeFromCodeCoverage]
    public class ErrorResponse
    {
        public int ResponseCode { get; set; }
        public string ExceptionType { get; set; }
        public string Message { get; set; }

        public ErrorResponse(int responseCode, Exception ex)
        {
            ResponseCode = responseCode;
            ExceptionType = ex.GetType().Name;
            Message = ex.Message;
        }
    }
}
