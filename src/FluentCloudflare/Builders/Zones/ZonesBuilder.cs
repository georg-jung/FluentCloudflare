using Cloudflare.Abstractions.Builders;
using Cloudflare.Abstractions.Builders.Zones;
using Cloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Builders.Zones
{
    internal class ZonesBuilder : UrlExtendingBuilder, IZonesSyntax
    {
        internal ZonesBuilder(IRequestBuilderFactory context) : base(context, "zones")
        {
        }

        public IZonesListSyntax List() => new ListBuilder(this);
    }
}
