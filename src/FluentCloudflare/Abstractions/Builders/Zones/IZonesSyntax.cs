using Cloudflare.Infrastructure;
using Cloudflare.Builders.Zones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Abstractions.Builders.Zones
{
    public interface IZonesSyntax : IFluentSyntax
    {
        IZonesListSyntax List();
    }
}
