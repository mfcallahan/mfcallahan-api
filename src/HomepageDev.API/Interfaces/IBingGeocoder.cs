namespace HomepageDev.API.Interfaces
{
    public interface IBingGeocoder
    {
        void GeocodeAddress(string address, string city, string state, string zipCode);
    }
}
