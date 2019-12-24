using System.Collections.Generic;
using System.Threading.Tasks;

using RestKami.Core.Interfaces;
using RestKami.Core.Models;

namespace RestKami.Core
{
    public sealed class RouteParameterVerifier : IRouteParameterVerifier
    {
        private readonly IRestApiService _restApiService;

        private readonly IPermutationHelper _permutationHelper;

        public RouteParameterVerifier(IRestApiService restApiService, IPermutationHelper permutationHelper)
        {
            _restApiService = restApiService;
            _permutationHelper = permutationHelper;
        }

        public async Task Verify(TestCase testCase)
        {
            var successfulTestCases = new List<Result>();
            var failedTestCases = new List<Result>();

            var permutations = _permutationHelper.Permutate(testCase.Seed.Values);

            foreach (var permutation in permutations)
            {
                string requestUrl = testCase.BaseUrl;

                int i = 0;
                foreach (string key in testCase.Seed.Keys)
                {
                    requestUrl = requestUrl.Replace($"[{key}]", permutation[i++]);
                }

                var result = await _restApiService.Get(requestUrl, testCase.ExpectedStatusCode);

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
