using FluentCloudflare.Abstractions.Builders;
using FluentCloudflare.Abstractions.Builders.Zones;
using FluentCloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Builders.Zones
{
    internal class ZonesBuilder : UrlExtendingBuilder, IZonesSyntax
    {
        internal ZonesBuilder(IRequestBuilderFactory context) : base(context, "zones")
        {
        }

        public IZonesListSyntax List() => new ListBuilder(this);
    }
}
