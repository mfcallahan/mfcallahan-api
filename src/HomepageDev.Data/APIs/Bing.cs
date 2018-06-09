﻿using HomepageDev.Data.POCOs;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Configuration;

namespace HomepageDev.Data.APIs
{
    public class Bing
    {
        readonly string BingKey;
        readonly string BingUrl;
        RestClient Client;

        public Bing()
        {
            BingKey = ConfigurationManager.AppSettings["bingKey"];
            BingUrl = ConfigurationManager.AppSettings["bingUrl"];

            CheckLimit();

            Client = new RestClient(BingUrl);
            Client.AddDefaultParameter("key", BingKey);
        }

        bool CheckLimit()
        {
            return true;
        }

        public void GeocodeAddress(ApiInputAddress inputAdr)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.AddParameter("key", BingKey);

            if (!string.IsNullOrEmpty(inputAdr.Address))
                request.AddParameter("addressLine", inputAdr.Address);
            if (!string.IsNullOrEmpty(inputAdr.City))
                request.AddParameter("locality", inputAdr.City);
            if (!string.IsNullOrEmpty(inputAdr.StateProv))
                request.AddParameter("adminDistrict", inputAdr.StateProv);
            if (!string.IsNullOrEmpty(inputAdr.PostalCode))
                request.AddParameter("inputAdr.PostalCode", inputAdr.PostalCode);
            if (!string.IsNullOrEmpty(inputAdr.Country))
                request.AddParameter("countryRegion", inputAdr.Country);

            var response = Client.Execute(request);

            BingGeocodeOutput output = JsonConvert.DeserializeObject<BingGeocodeOutput>(response.Content);

            foreach (var r in output.resourceSets[0].resources)
            {
                ApiOutputAddress o = new ApiOutputAddress();
                o.OutputAddress = r.address.addressLine;
                o.OutputCity = r.address.locality;
                o.OutputStateProv = r.address.adminDistrict;
                o.OutputPostalCode = r.address.postalCode;
                o.OutputCountry = r.address.countryRegion;
                o.Confidence = r.confidence;
                o.Longitude = r.geocodePoints[0].coordinates[0];
                o.Latitude = r.geocodePoints[0].coordinates[1];
                o.Source = "Bing";

                inputAdr.OutputAddresses.Add(o);
            }
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
