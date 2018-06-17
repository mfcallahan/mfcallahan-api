using HomepageDev.Data.POCOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace HomepageDev.Data.APIs
{
    public static class IpDataApi
    {
        const string _url = "https://api.ipdata.co/";

        public static IpDataResponse GetIpInfo(string ip)
        {
            if (string.IsNullOrEmpty(ip))
                return new IpDataResponse { status = "Error: input IP address is null."};

            try
            {
                using (var client = new WebClient())
                {
                    var jsonResponse = client.DownloadString(_url + ip);
                    IpDataResponse response = JsonConvert.DeserializeObject<IpDataResponse>(jsonResponse);
                    response.status = "OK";

                    return response;
                }
            }
            catch (Exception ex)
            {
                return new IpDataResponse { status = "Error: " + ex };
            }
        }
    }
}
