using FluentCloudflare.Abstractions.Builders.Zones;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Builders.Zones
{
    internal class ZonesBuilder : UrlExtender, IZonesSyntax
    {
        internal ZonesBuilder(IRequestBuilderFactory context) : base(context, "zones")
        {
        }

        public IZonesCreateSyntax Create(string domainName, string accountId)
            => new CreateBuilder(this, domainName, accountId);

        public IZonesListSyntax List() => new ListBuilder(this);
    }
}
