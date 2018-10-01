using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomepageDev.Geocoder.POCOs
{
    public class InputAddress
    {
        public InputAddress()
        {
            
        }

        public InputAddress(string address, string city, string stateProv, string postalCode, string country)
        {
            Address = address;
            City = city;
            StateProv = stateProv;
            PostalCode = postalCode;
            Country = country;
            OutputAddresses = new List<OutputAddress>();
        }

        public string Address { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Status { get; set; }
        public IList<OutputAddress> OutputAddresses { get; set; }
    }
}