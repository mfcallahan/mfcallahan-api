using System.Threading.Tasks;

namespace HomepageDev.API.Interfaces
{
    public interface IBingGeocoder
    {
        Task GeocodeAddressAsync(string address, string city, string stateProvince, string postalCode, string country);
        Task GeocodeAddressBacthAsync();
    }
}
