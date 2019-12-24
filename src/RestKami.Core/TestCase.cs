using System.Collections.Generic;

namespace RestKami.Core
{
    public sealed class TestCase
    {
        public string BaseUrl { get; set; }

        public Dictionary<string, string[]> Seed { get; set; }

        public int ExpectedStatusCode { get; set; }
    }
}