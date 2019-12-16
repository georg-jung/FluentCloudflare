using FluentCloudflare.Abstractions.Builders;
using FluentCloudflare.Abstractions.Builders.Dns;
using FluentCloudflare.Abstractions.Builders.Zones;
using FluentCloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Builders
{
    public class ZoneBuilder : IZoneSyntax, IRequestBuilderFactory
    {
        private readonly IRequestBuilderFactory context;
        private readonly string identifier;

        internal ZoneBuilder(IRequestBuilderFactory context, string identifier)
        {
            this.context = context;
            this.identifier = identifier;
        }

        public IDnsSyntax Dns => new Dns.DnsBuilder(this);

        IRequestBuilder IRequestBuilderFactory.CreateRequestBuilder()
        {
            var builder = context.CreateRequestBuilder();
            builder.UrlSegments.Add("zones");
            builder.UrlSegments.Add(identifier);
            return builder;
        }
    }
}
