using System.Collections.Generic;
using System.Threading.Tasks;

using RestKami.Core.Models;

namespace RestKami.Core.Interfaces
{
    public interface IRestApiService
    {
        Task<Result> Get(
            string baseUrl,
            Dictionary<string, string> headers,
            int expectedStatusCode = 200,
            uint timeoutInMilliseconds = 1000);
    }
}