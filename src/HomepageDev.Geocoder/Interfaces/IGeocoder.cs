using HomepageDev.Geocoder.POCOs;
using HomepageDev.Geocoder.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomepageDev.Geocoder.Interfaces
{
    interface IGeocoder
    {
        IList<InputAddress> InputAddresses { get; set; }
        DateTime RequestTime { get; set; }
        bool IsSuccess { get; set; }

        void GetGeocodeResults();
    }
}
