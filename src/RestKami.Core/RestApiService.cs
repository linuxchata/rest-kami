using System;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using RestKami.Core.Interfaces;
using RestKami.Core.Models;

namespace RestKami.Core
{
    public class RestApiService : IRestApiService
    {
        private readonly ILogger _logger;

        public RestApiService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<RestApiService>();
        }

        public async Task<Result> Get(string baseUrl, int expectedStatusCode = 200, uint timeoutInMilliseconds = 1000)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }

            var result = new Result { Url = baseUrl };

            try
            {
                var client = new HttpClient
                {
                    Timeout = TimeSpan.FromMilliseconds(timeoutInMilliseconds)
                };

                var response = await client.GetAsync(baseUrl);

                int resultStatusCode = (int)response.StatusCode;

                if (resultStatusCode == expectedStatusCode)
                {
                    result.SetResult(true, resultStatusCode);
                    _logger.LogDebug("URL {baseUrl} has been successfully requested", baseUrl);
                }
                else
                {
                    result.SetResult(false, resultStatusCode);
                    _logger.LogWarning(
                        "Unexpected status code {resultStatusCode} while requesting URL {baseUrl}",
                        resultStatusCode,
                        baseUrl);
                }
            }
            catch (Exception e)
            {
                result.SetError(e.Message);
                _logger.LogError(e, "Error requesting URL {baseUrl}", baseUrl);
            }

            return result;
        }

    }
}
