using System;
using System.Collections.Generic;

using RestKami.Core.Interfaces;

namespace RestKami.Core
{
    public sealed class RouteParameterTestCaseBuilder : ITestCaseBuilder
    {
        private readonly RouteParameterTestCase routeParameterTestCase;

        public RouteParameterTestCaseBuilder()
        {
            this.routeParameterTestCase = new RouteParameterTestCase
            {
                RouterParametersSeed = new Dictionary<string, string[]>(),
                Headers = new Dictionary<string, string>()
            };
        }

        public RouteParameterTestCaseBuilder VerifiableUrl(string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }

            bool result = Uri.TryCreate(baseUrl, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!result)
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }

            this.routeParameterTestCase.BaseUrl = baseUrl;

            return this;
        }

        public RouteParameterTestCaseBuilder WithRouterParameter(string forParam, string[] seed)
        {
            if (string.IsNullOrWhiteSpace(forParam))
            {
                throw new ArgumentNullException(nameof(forParam));
            }

            if (seed == null)
            {
                throw new ArgumentNullException(nameof(seed));
            }

            if (this.routeParameterTestCase.RouterParametersSeed?.ContainsKey(forParam) ?? false)
            {
                throw new ArgumentException(nameof(forParam));
            }

            this.routeParameterTestCase.RouterParametersSeed?.Add(forParam, seed);

            return this;
        }

        public RouteParameterTestCaseBuilder WithHeader(string headerKey, string headerValue)
        {
            if (string.IsNullOrWhiteSpace(headerKey))
            {
                throw new ArgumentNullException(nameof(headerKey));
            }

            if (string.IsNullOrWhiteSpace(headerValue))
            {
                throw new ArgumentNullException(nameof(headerValue));
            }

            if (this.routeParameterTestCase.Headers?.ContainsKey(headerKey) ?? false)
            {
                throw new ArgumentException(nameof(headerKey));
            }

            this.routeParameterTestCase.Headers?.Add(headerKey, headerValue);

            return this;
        }

        public RouteParameterTestCaseBuilder ShouldReturnStatusCode(int statusCode)
        {
            this.routeParameterTestCase.ExpectedStatusCode = statusCode;

            return this;
        }

        public RouteParameterTestCase Build()
        {
            return this.routeParameterTestCase;
        }
    }
}
