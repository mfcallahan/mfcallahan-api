using System;
using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.Models.ApiResponses
{
    [ExcludeFromCodeCoverage]
    public class ErrorResponse
    {
        public int ResponseCode { get; }
        public string ExceptionType { get; }
        public string Message { get; }

        public ErrorResponse(int responseCode, Exception ex)
        {
            ResponseCode = responseCode;
            ExceptionType = ex.GetType().Name;
            Message = ex.Message;
        }
    }
}
