using HomepageDev.Data.POCOs;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace HomepageDev.Data.APIs
{
    public class BingGeocoder
    {
        readonly string BingKey;
        readonly string BingUrl;
        readonly RestClient Client;

        public BingGeocoder()
        {
            BingKey = ConfigurationManager.AppSettings["bingKey"];
            BingUrl = ConfigurationManager.AppSettings["bingUrl"];

            //CheckLimit();

            Client = new RestClient(BingUrl);
            Client.AddDefaultParameter("key", BingKey);
        }

        bool CheckLimit()
        {
            throw new NotImplementedException();
        }

        public void GeocodeAddress(InputAdr adr)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.AddParameter("key", BingKey);

            if (!string.IsNullOrEmpty(adr.InputAddress))
                request.AddParameter("addressLine", adr.InputAddress);
            if (!string.IsNullOrEmpty(adr.InputCity))
                request.AddParameter("locality", adr.InputCity);
            if (!string.IsNullOrEmpty(adr.InputStateProv))
                request.AddParameter("adminDistrict", adr.InputStateProv);
            if (!string.IsNullOrEmpty(adr.InputPostalCode))
                request.AddParameter("inputAdr.PostalCode", adr.InputPostalCode);
            if (!string.IsNullOrEmpty(adr.InputCountry))
                request.AddParameter("countryRegion", adr.InputCountry);

            IRestResponse response = null;

            try
            {
                response = Client.Execute(request);
            }
            catch (Exception ex)
            {
                adr.Status = "BingGeocoder.GeocodeAddress() error: " + ex;
                return;
            }

            if (!response.IsSuccessful)
            {
                adr.Status = "BingGeocoder.GeocodeAddress() error: response.IsSuccessful = " + response.IsSuccessful + "; response.StatusDescription = " + response.StatusDescription;
                return;
            }

            BingGeocodeOutput output = JsonConvert.DeserializeObject<BingGeocodeOutput>(response.Content);

            foreach (var r in output.resourceSets[0].resources)
            {
                adr.OutputAddresses.Add(new OutputAdr()
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

    public class BingGeocodeOutput
    {
        public string authenticationResultCode { get; set; }
        public string brandLogoUri { get; set; }
        public string copyright { get; set; }
        public IList<BingResourceSet> resourceSets { get; set; }
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public string traceId { get; set; }
    }

    public class BingResourceSet
    {
        public int estimatedTotal { get; set; }
        public IList<BingResource> resources { get; set; }
    }

    public class BingResource
    {
        public string __type { get; set; }
        public IList<double> bbox { get; set; }
        public string name { get; set; }
        public BingPoint point { get; set; }
        public BingAddress address { get; set; }
        public string confidence { get; set; }
        public string entityType { get; set; }
        public IList<BingGeocodePoint> geocodePoints { get; set; }
        public IList<string> matchCodes { get; set; }
    }

    public class BingPoint
    {
        public string type { get; set; }
        public IList<double> coordinates { get; set; }
    }

    public class BingAddress
    {
        public string addressLine { get; set; }
        public string adminDistrict { get; set; }
        public string adminDistrict2 { get; set; }
        public string countryRegion { get; set; }
        public string formattedAddress { get; set; }
        public string locality { get; set; }
        public string postalCode { get; set; }
    }

    public class BingGeocodePoint
    {
        public string type { get; set; }
        public IList<double> coordinates { get; set; }
        public string calculationMethod { get; set; }
        public IList<string> usageTypes { get; set; }
    }
}