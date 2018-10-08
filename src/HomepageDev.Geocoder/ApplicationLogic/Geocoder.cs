using HomepageDev.Geocoder.Interfaces;
using HomepageDev.Geocoder.POCOs;
using HomepageDev.Geocoder.Services;
using HomepageDev.Geocoder.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace HomepageDev.Geocoder.ApplicationLogic
{
    public class Geocoder : IGeocoder
    {
        private Logger logger { get; set; }
        public IList<InputAddress> InputAddresses { get; set; }
        public DateTime RequestTime { get; set; }
        public bool IsSuccess { get; set; }
        private bool useBing = Convert.ToBoolean(ConfigurationManager.AppSettings["useBing"]);
        private bool useSomeOtherSource = Convert.ToBoolean(ConfigurationManager.AppSettings["useSource"]);
        private const int LIST_CHUNK_SIZE = 100;

        public Geocoder(IList<InputAddress> inputAddresses)
        {
            InputAddresses = inputAddresses;
        }

        public Geocoder(InputAddress inputAddress)
        {
            InputAddresses = new List<InputAddress> { inputAddress };
        }

        public async void GetGeocodeResultsAsync()
        {
            var inputAddressChunks = InputAddresses.SplitList(LIST_CHUNK_SIZE);

            Parallel.ForEach(inputAddressChunks, new ParallelOptions { MaxDegreeOfParallelism = 10 }, (chunk) =>
            {
                if (useBing)
                {
                    var bingLocationsApi = new BingLocationsApi();
                    var adrsToGeocode = chunk.Where(x => x.Success);

                    try
                    {
                        bingLocationsApi.GeocodeAddresses(adrsToGeocode);
                    }
                    catch (Exception ex)
                    {
                        logger.LogMessgae(ex.ToString());
                    }
                   
                }

            });
        }

        public void LogInfo()
        {

        }
    }
}