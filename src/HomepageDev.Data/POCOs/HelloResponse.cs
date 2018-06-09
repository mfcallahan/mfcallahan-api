using System.Collections.Generic;

namespace HomepageDev.Data.POCOs
{
    public class HelloResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public IList<string> Methods { get; set; }

        public HelloResponse(string status, string message)
        {
            Status = status;
            Message = message;

            Methods = new List<string>
            {
                "mfcallahan-dev.com/api/About",
                "mfcallahan-dev.com/api/Hello",
                "mfcallahan-dev.com/api/Geocode?address={}&city={}&stateProv={}&postalCode={}&country={}",
                "mfcallahan-dev.com/api/GetDelayedResponse?waitSeconds={}",
                "mfcallahan-dev.com/api/IpInfo?ip={}",
                "mfcallahan-dev.com/api/RandomString?length={}&useNums={}"
            };
        }
    }
}
