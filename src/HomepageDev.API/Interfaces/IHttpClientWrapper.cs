using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomepageDev.API.Interfaces
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(Uri uri);
    }
}
