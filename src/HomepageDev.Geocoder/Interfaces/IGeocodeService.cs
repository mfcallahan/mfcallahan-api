using HomepageDev.Geocoder.POCOs;
using System.Collections.Generic;

namespace HomepageDev.Geocoder.Interfaces
{
    public interface IGeocodeService
    {
        void GeocodeAddresses(IEnumerable<InputAddress> inputAddresses);
    }
}