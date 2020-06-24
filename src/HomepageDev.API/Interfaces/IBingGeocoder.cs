using System.Threading.Tasks;

namespace HomepageDev.API.Interfaces
{
    public interface IBingGeocoder
    {
        Task GeocodeAddress(string address, string city, string state, string zipCode);
    }
}
