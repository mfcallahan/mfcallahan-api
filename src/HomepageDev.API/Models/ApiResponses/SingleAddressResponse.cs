using HomepageDev.API.Models.Bing;
using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.API.Models.ApiResponses
{
    [ExcludeFromCodeCoverage]
    public class SingleAddressResponse
    {
        public string OutputFormattedAddress { get; set; }
        public string OutputAddress { get; set; }
        public string OutputNeighborhood { get; set; }
        public string OutputPostalCode { get; set; }
        public string OutputCity { get; set; }
        public string OutputCounty { get; set; }
        public string OutputStateProvince { get; set; }
        public string OutputCountry { get; set; }
        public string Confidence { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
