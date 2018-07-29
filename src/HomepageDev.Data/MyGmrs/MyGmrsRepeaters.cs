using System;
using HomepageDev.Data.POCOs;
using Newtonsoft.Json;
using System.Configuration;
using System.Net;
using System.IO;
using System.Reflection;

namespace HomepageDev.Data.MyGmrs
{
    public class MyGmrsRepeaters
    {
        private readonly string _url = ConfigurationManager.AppSettings["myGmrsRepeatersUrl"];

        public MyGmrsRepeatersResponse GetRepeaters()
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
                    webClient.ResponseHeaders[HttpResponseHeader.Allow] = "*";
                    webClient.ResponseHeaders[HttpResponseHeader.ContentType] = "application/json";
                    var jsonResponse = webClient.DownloadString(_url);
                    MyGmrsRepeatersResponse response = JsonConvert.DeserializeObject<MyGmrsRepeatersResponse>(jsonResponse);

                }
            }
            catch (Exception ex)
            {
                return new MyGmrsRepeatersResponse
                {
                    RequestStatus = "MyGmrs.GetRepeaters() error: " + ex
                };
            }

            //MyGmrsRepeatersResponse output = JsonConvert.DeserializeObject<MyGmrsRepeatersResponse>(response.Content);
            //output.RequestStatus = "OK";

            //return output;
            //TODO: figure out why repeaters in reply is empty
            return null;
        }

        public string GetRepeatersFromFile()
        {
            using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("HomepageDev.Data.MyGmrs.repeaters.json"))
            {
                TextReader tr = new StreamReader(s);
                return tr.ReadToEnd();
            }
        }
    }
}