using HomepageDev.Geocoder.Interfaces;
using HomepageDev.Geocoder.POCOs;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HomepageDev.Geocoder.Services
{
    public class BingLocationsApi : IGeocodeService
    {
        readonly string BingKey;
        readonly string BingUrl;
        readonly RestClient BingRestClient;

        public BingLocationsApi()
        {
            BingKey = ConfigurationManager.AppSettings["bingKey"];
            BingUrl = ConfigurationManager.AppSettings["bingUrl"];

            //CheckLimit();

            BingRestClient = new RestClient(BingUrl);
            BingRestClient.AddDefaultParameter("key", BingKey);
        }

        bool CheckLimit()
        {
            throw new NotImplementedException();
        }

        public void GeocodeAddresses(IEnumerable<InputAddress> inputAddresses)
        {
            foreach (var adr in inputAddresses)
            {
                RestRequest request = new RestRequest(Method.GET);
                request.AddParameter("key", BingKey);

                if (!string.IsNullOrEmpty(adr.Address))
                    request.AddParameter("addressLine", adr.Address);
                if (!string.IsNullOrEmpty(adr.City))
                    request.AddParameter("locality", adr.City);
                if (!string.IsNullOrEmpty(adr.StateProv))
                    request.AddParameter("adminDistrict", adr.StateProv);
                if (!string.IsNullOrEmpty(adr.PostalCode))
                    request.AddParameter("inputAdr.PostalCode", adr.PostalCode);
                if (!string.IsNullOrEmpty(adr.Country))
                    request.AddParameter("countryRegion", adr.Country);

                IRestResponse response = null;

                try
                {
                    response = BingRestClient.Execute(request);
                }
                catch (Exception ex)
                {
                    adr.Status = "BingGeocoder.GeocodeAddress() error: " + ex;                    
                }

                if (!response.IsSuccessful)
                {
                    adr.Status = "BingGeocoder.GeocodeAddress() error: response.IsSuccessful = " + response.IsSuccessful + "; response.StatusDescription = " + response.StatusDescription;
                    
                }

                BingOutput output = JsonConvert.DeserializeObject<BingOutput>(response.Content);

                foreach (var r in output.resourceSets[0].resources)
                {
                    adr.OutputAddresses.Add(new OutputAddress()
                    {
                        Address = r.address.addressLine,
                        City = r.address.locality,
                        StateProv = r.address.adminDistrict,
                        PostalCode = r.address.postalCode,
                        Country = r.address.countryRegion,
                        Confidence = r.confidence,
                        Longitude = r.geocodePoints[0].coordinates[0],
                        Latitude = r.geocodePoints[0].coordinates[1],
                        Source = "Bing"
                    });
                }

                adr.Status = "OK";
            }

        }

    }
}