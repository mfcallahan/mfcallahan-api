using HomepageDev.API.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomepageDev.API
{
    public class HttpClientWrapper : IHttpClientWrapper, IDisposable
    {
        private HttpClient HttpClient;
        private const int MaxHttpClientConnections = 10;

        public HttpClientWrapper()
        {
            HttpClient = new HttpClient();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.DefaultConnectionLimit = MaxHttpClientConnections;
        }

        public async Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            return await HttpClient.GetAsync(uri).ConfigureAwait(false);
        }

        public void Dispose()
        {
            HttpClient.Dispose();
            HttpClient = null;
        }
    }
}
