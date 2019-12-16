using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Abstractions.Builders.Dns
{
    public interface IDnsUpdateSyntax : IFluentSyntax, IDnsChangeSyntax<IDnsUpdateSyntax>
    {
        // has no additional properties
    }
}
