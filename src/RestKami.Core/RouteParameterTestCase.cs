using System.Collections.Generic;

namespace RestKami.Core
{
    public sealed class RouteParameterTestCase
    {
        public string BaseUrl { get; set; }

        public Dictionary<string, string[]> RouterParametersSeed { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public int ExpectedStatusCode { get; set; }
    }
}