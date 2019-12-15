using Cloudflare.Abstractions.Builders.Dns;
using Cloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Abstractions.Builders.Zones
{
    public interface IZoneSyntax : IFluentSyntax
    {
        IDnsSyntax Dns { get; }
    }
}
