using Cloudflare.Abstractions.Builders.Zones;
using Cloudflare.Api.Entities;
using Cloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Abstractions.Builders
{
    public interface IAuthorizedSyntax : IFluentSyntax
    {
        IZoneSyntax Zone(Zone zone);
        IZoneSyntax Zone(string identifier);
        IZonesSyntax Zones { get; }
    }
}
