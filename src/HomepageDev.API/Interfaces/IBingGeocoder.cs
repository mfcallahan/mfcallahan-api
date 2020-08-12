using HomepageDev.API.Models.ApiResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomepageDev.API.Interfaces
{
    public interface IBingGeocoder
    {
        Task<IList<SingleAddressGeocodeResponse>> GeocodeAddressAsync(string address, string city, string stateProvince, string postalCode, string country);
        Task GeocodeAddressBacthAsync();
    }
}
