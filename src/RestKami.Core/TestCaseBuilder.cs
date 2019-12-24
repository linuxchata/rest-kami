using System;
using System.Collections.Generic;

using RestKami.Core.Interfaces;

namespace RestKami.Core
{
    public sealed class TestCaseBuilder : ITestCaseBuilder
    {
        private readonly TestCase _testCase;

        public TestCaseBuilder()
        {
            _testCase = new TestCase { Seed = new Dictionary<string, string[]>() };
        }

        public TestCaseBuilder VerifiableUrl(string baseUrl)
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

            _testCase.BaseUrl = baseUrl;

            return this;
        }

        public TestCaseBuilder WithSeed(string[] seed, string forParam)
        {
            if (seed == null)
            {
                throw new ArgumentNullException(nameof(seed));
            }

            if (string.IsNullOrWhiteSpace(forParam))
            {
                throw new ArgumentNullException(nameof(forParam));
            }

            if (_testCase.Seed?.ContainsKey(forParam) ?? false)
            {
                throw new ArgumentException(nameof(forParam));
            }

            _testCase.Seed?.Add(forParam, seed);

            return this;
        }

        public TestCaseBuilder ShouldReturnStatusCode(int statusCode)
        {
            _testCase.ExpectedStatusCode = statusCode;

            return this;
        }

        public TestCase Build()
        {
            return _testCase;
        }
    }
}
