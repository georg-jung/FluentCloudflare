using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;

namespace FluentCloudflare.Abstractions.Infrastructure
{
    internal interface IRequestBuilder
    {
        Uri BaseUrl { get; set; }
        ExpandoObject Body { get; }
        Dictionary<string, string> Headers { get; }
        HttpMethod Method { get; set; }
        ExpandoObject QueryStringParameters { get; }
        List<string> UrlSegments { get; }

        HttpRequestMessage Build();
    }
}