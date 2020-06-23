using HomepageDev.API.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomepageDev.API
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private HttpClient HttpClient;
        private const int MaxHttpClientConnections = 1;

        public HttpClientWrapper()
        {
            HttpClient = new HttpClient();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.DefaultConnectionLimit = MaxHttpClientConnections;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await HttpClient.GetAsync(url);
        }
    }
}
