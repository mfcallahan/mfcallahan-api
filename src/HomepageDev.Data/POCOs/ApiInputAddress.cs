using System.Collections.Generic;

namespace HomepageDev.Data.POCOs
{
    public class ApiInputAddress
    {
        public ApiInputAddress(string address, string city, string stateProv, string postalCode, string country)
        {
            Address = address;
            City = city;
            StateProv = stateProv;
            PostalCode = postalCode;
            Country = country;
            OutputAddresses = new List<ApiOutputAddress>();
        }

        public string Address { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public IList<ApiOutputAddress> OutputAddresses { get; set; }
    }
}
