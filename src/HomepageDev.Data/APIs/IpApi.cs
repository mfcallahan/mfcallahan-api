using HomepageDev.Data.POCOs;
using Newtonsoft.Json;
using System.Net;

namespace HomepageDev.Data
{
    public static class IpApi
    {
        const string _url = "http://ip-api.com/json/";

        public static IpLocation GetIpInfo(string ip)
        {
            if (string.IsNullOrEmpty(ip))
                return null;

            using (var client = new WebClient())
            {
                dynamic result = JsonConvert.DeserializeObject(client.DownloadString("http://ip-api.com/json/" + ip));

                if (result.status == "success")
                {
                    return new IpLocation
                    {
                        Name = result.@as,
                        IpAddress = ip,
                        Isp = result.isp,
                        City = result.city,
                        Country = result.country,
                        Lat = result.lat,
                        Lon = result.lon,
                        Region = result.region,
                        Status = result.status,
                        TimeZone = result.timezone,
                        PostalCode = result.zip
                    };
                }

                return null;
            }
        }
    }
}
