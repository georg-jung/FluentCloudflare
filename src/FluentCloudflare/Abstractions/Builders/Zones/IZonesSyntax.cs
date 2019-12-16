using FluentCloudflare.Infrastructure;
using FluentCloudflare.Builders.Zones;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Abstractions.Builders.Zones
{
    public interface IZonesSyntax : IFluentSyntax
    {
        IZonesListSyntax List();
    }
}
