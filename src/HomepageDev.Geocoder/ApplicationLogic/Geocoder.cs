using HomepageDev.Geocoder.POCOs;
using HomepageDev.Geocoder.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomepageDev.Geocoder.ApplicationLogic
{
    public class Geocoder
    {
        private Logger logger { get; set; }

        public string source { get; set; }
        public List<InputAddress> InputAddresses { get; set; }
        public bool Success { get; set; }
        public DateTime RequestTime { get; set; }

        public Geocoder(List<InputAddress> inputAddresses)
        {
            InputAddresses = inputAddresses;
        }

        public Geocoder(List<InputAddress> inputAddresses, string source)
        {
            InputAddresses = inputAddresses;
        }

        public async void GetGeocodeResultsAsync()
        {

        }

        public void LogInfo()
        {

        }
    }
}