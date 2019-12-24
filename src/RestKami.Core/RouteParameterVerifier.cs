using System.Collections.Generic;
using System.Threading.Tasks;

using RestKami.Core.Interfaces;
using RestKami.Core.Models;

namespace RestKami.Core
{
    public sealed class RouteParameterVerifier : IRouteParameterVerifier
    {
        private readonly IRestApiService restApiService;

        private readonly IPermutationHelper permutationHelper;

        public RouteParameterVerifier(IRestApiService restApiService, IPermutationHelper permutationHelper)
        {
            this.restApiService = restApiService;
            this.permutationHelper = permutationHelper;
        }

        public async Task Verify(RouteParameterTestCase testCase)
        {
            var successfulTestCases = new List<Result>();
            var failedTestCases = new List<Result>();

            var routePermutations = this.permutationHelper.Permutate(testCase.RouterParametersSeed.Values);

            foreach (var routePermutation in routePermutations)
            {
                string requestUrl = testCase.BaseUrl;

                int i = 0;
                foreach (string key in testCase.RouterParametersSeed.Keys)
                {
                    requestUrl = requestUrl.Replace($"[{key}]", routePermutation[i++]);
                }

                var result = await this.restApiService.Get(requestUrl, testCase.Headers, testCase.ExpectedStatusCode);

                if (result.Value)
                {
                    successfulTestCases.Add(result);
                }
                else
                {
                    failedTestCases.Add(result);
                }
            }
        }
    }
}
