using Cloudflare.Abstractions.Builders.Zones;
using Cloudflare.Api;
using Cloudflare.Api.Entities;
using Cloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cloudflare.Abstractions.Builders
{
    public interface IAuthorizedSyntax : IFluentSyntax
    {
        IZoneSyntax Zone(Zone zone);
        IZoneSyntax Zone(string identifier);
        IZonesSyntax Zones { get; }
    }
}
