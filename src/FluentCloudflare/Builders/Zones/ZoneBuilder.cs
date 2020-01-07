using FluentCloudflare.Abstractions.Builders;
using FluentCloudflare.Abstractions.Builders.Dns;
using FluentCloudflare.Abstractions.Builders.Zones;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Builders.Zones
{
    internal class ZoneBuilder : UrlExtender, IZoneSyntax
    {
        internal ZoneBuilder(IRequestBuilderFactory context, string identifier) : base(context, "zones", identifier)
        {
        }

        public IDnsSyntax Dns => new Dns.DnsBuilder(this);
    }
}
