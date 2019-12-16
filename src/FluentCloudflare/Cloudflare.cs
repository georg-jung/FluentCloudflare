using FluentCloudflare.Abstractions.Builders;
using FluentCloudflare.Abstractions.Builders.IPs;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Builders;
using FluentCloudflare.Builders.IPs;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare
{
    public static class Cloudflare
    {
        private const string DefaultEndpointUrl = "https://api.cloudflare.com/client/v4/";
        public static Uri EndpointUrl { get; set; } = new Uri(DefaultEndpointUrl);

        public static ITokenAuthorizedSyntax WithToken(string token)
        {
            return new TokenAuthorizedBuilder(new EndpointFactory(), token);
        }

        public static IAuthorizedSyntax WithKey(string apiKey, string email)
        {
            return new AuthorizedBuilder(new EndpointFactory(), apiKey, email);
        }

        public static IIPsSyntax IPs => new IPsBuilder(new EndpointFactory());

        private class EndpointFactory : IRequestBuilderFactory
        {
            public IRequestBuilder CreateRequestBuilder()
            {
                var builder = new RequestBuilder
                {
                    BaseUrl = EndpointUrl
                };
                return builder;
            }
        }
    }
}
