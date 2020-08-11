using HomepageDev.API.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomepageDev.API
{
    /// <summary>
    /// A wrapper class for HttpClient to allow for easier mocking and unit testing of methods making HTTP requests.
    /// </summary>
    public sealed class HttpClientWrapper : IHttpClientWrapper, IDisposable
    {
        private HttpClient HttpClient;
        private const int MaxHttpClientConnections = 10; //TODO: set this in config file?

        public HttpClientWrapper()
        {
            HttpClient = new HttpClient();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.DefaultConnectionLimit = MaxHttpClientConnections;
        }

        /// <summary>
        /// A wrapper method for HttpClient.GetAsync(); executes an HTTP GET request.
        /// </summary>
        /// <param name="uri">The full uniform resoure identifier (URI) of the API endpoint</param>
        /// <returns>HttpResponseMessage</returns>
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
