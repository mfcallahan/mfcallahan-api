﻿using System;
using HomepageDev.Data.POCOs;
using Newtonsoft.Json;
using System.Configuration;
using System.Net;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace HomepageDev.Data.MyGmrs
{
    public class MyGmrsRepeaters
    {
        public string Repeaters;
        private readonly string _url = ConfigurationManager.AppSettings["myGmrsRepeatersUrl"];

        public MyGmrsRepeaters()
        {
            Repeaters = GetRepeatersFromFile();
        }

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

        private string GetRepeatersFromFile()
        {
            using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("HomepageDev.Data.MyGmrs.repeaters.json"))
            {
                TextReader tr = new StreamReader(s);
                return tr.ReadToEnd();
            }
        }

        public Repeater GetRepeaterInfoFromFile(string id)
        {
            RepeaterInfo r = JsonConvert.DeserializeObject<RepeaterInfo>(Repeaters);
            return r.repeaters.Where(x => x.id == id).FirstOrDefault();
        }
    }

    public class RepeaterInfo
    {
        public bool authenticated { get; set; }
        public List<Repeater> repeaters { get; set; }
    }

    public class Repeater
    {
        public string id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string owner { get; set; }
        public string network_id { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string description { get; set; }
        public Location location { get; set; }
        public string radius { get; set; }
        public string haat { get; set; }
    }

    public class Location
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}