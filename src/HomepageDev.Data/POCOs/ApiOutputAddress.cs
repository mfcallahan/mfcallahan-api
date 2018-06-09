namespace HomepageDev.Data.POCOs
{
    public class ApiOutputAddress
    {
        public string OutputAddress { get; set; }
        public string OutputCity { get; set; }
        public string OutputStateProv { get; set; }
        public string OutputPostalCode { get; set; }
        public string OutputCountry { get; set; }
        //public string Accuracy { get; set; }
        //public string Precision { get; set; }
        public string Confidence { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Source { get; set; }
    }
}
