using System.Collections.Generic;

namespace HomepageDev.Data.POCOs
{
    public class InputAdr
    {
        public InputAdr(string address, string city, string stateProv, string postalCode, string country)
        {
            InputAddress = address;
            InputCity = city;
            InputStateProv = stateProv;
            InputPostalCode = postalCode;
            InputCountry = country;
            OutputAddresses = new List<OutputAdr>();
        }

        public string InputAddress { get; set; }
        public string InputCity { get; set; }
        public string InputStateProv { get; set; }
        public string InputPostalCode { get; set; }
        public string InputCountry { get; set; }
        public string Status { get; set; }
        public IList<OutputAdr> OutputAddresses { get; set; }
    }
}
