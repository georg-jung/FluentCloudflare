using FluentCloudflare.Abstractions.Builders.Dns;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Abstractions.Builders.Zones
{
    public interface IZoneSyntax : IFluentSyntax
    {
        IDnsSyntax Dns { get; }
    }
}
