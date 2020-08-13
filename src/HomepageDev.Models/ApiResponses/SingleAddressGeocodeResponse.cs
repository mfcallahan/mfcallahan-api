using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.Models.ApiResponses
{
    [ExcludeFromCodeCoverage]
    public class SingleAddressGeocodeResponse
    {
        public string OutputAddress { get; set; }
        public string Confidence { get; set; }
        public string MatchType { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
