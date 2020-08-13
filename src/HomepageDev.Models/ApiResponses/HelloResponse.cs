using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.Models.ApiResponses
{
    [ExcludeFromCodeCoverage]
    public class HelloResponse
    {
        public string Configuration { get; }
        public string Message { get; }

        public HelloResponse(string configuration, string message)
        {
            Configuration = configuration;
            Message = message;
        }
    }
}
