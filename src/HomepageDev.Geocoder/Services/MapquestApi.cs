using HomepageDev.Geocoder.Interfaces;
using HomepageDev.Geocoder.POCOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HomepageDev.Geocoder.Services
{
    public class MapquestApi : IGeocodeService
    {
        public readonly string ApiKey;

        public MapquestApi()
        {
            ApiKey = ConfigurationManager.AppSettings["mapQuestKey"];
        }
        

        public void GeocodeAddresses(IEnumerable<InputAddress> inputAddresses)
        {
            throw new NotImplementedException();
        }
    }
}