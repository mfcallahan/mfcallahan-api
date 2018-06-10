namespace HomepageDev.Data.POCOs
{
    public class GmrsRepeater
    {
        string urlMyGRMS;
        string rX_Frequency;
        double? lat;
        double? lon;

        public string Name { get; set; }
        public string UrlMyGmrs { get; set; }
        public string RxFrequency { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public GmrsRepeater(string name, string urlMyGMrs, string rxFrequency, double? latitude, double? longitude)
        {
            Name = name;
            UrlMyGmrs = urlMyGMrs;
            RxFrequency = rxFrequency;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
