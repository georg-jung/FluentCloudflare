using FluentCloudflare.Abstractions.Builders.Accounts;
using FluentCloudflare.Abstractions.Builders.Zones;
using FluentCloudflare.Api;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentCloudflare.Abstractions.Builders
{
    public interface IAuthorizedSyntax : IFluentSyntax
    {
        IAccountsSyntax Accounts { get; }
        IZoneSyntax Zone(Zone zone);
        IZoneSyntax Zone(string identifier);
        IZonesSyntax Zones { get; }
    }
}
