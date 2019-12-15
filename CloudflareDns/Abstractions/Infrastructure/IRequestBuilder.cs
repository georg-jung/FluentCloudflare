using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;

namespace Cloudflare.Abstractions.Infrastructure
{
    internal interface IRequestBuilder
    {
        string BaseUrl { get; set; }
        ExpandoObject Body { get; }
        Dictionary<string, string> Headers { get; }
        HttpMethod Method { get; set; }
        ExpandoObject QueryParameters { get; }
        List<string> UrlSegments { get; }

        HttpRequestMessage Build();
    }
}