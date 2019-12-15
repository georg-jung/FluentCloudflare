using Cloudflare.Abstractions.Builders;
using Cloudflare.Abstractions.Builders.Dns;
using Cloudflare.Abstractions.Builders.Zones;
using Cloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Builders
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
