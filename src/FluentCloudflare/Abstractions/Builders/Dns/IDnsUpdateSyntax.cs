using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Api.Entities;
using Cloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Abstractions.Builders.Dns
{
    public interface IDnsUpdateSyntax : IFluentSyntax, IDnsChangeSyntax<IDnsUpdateSyntax>
    {
        // has no additional properties
    }
}
