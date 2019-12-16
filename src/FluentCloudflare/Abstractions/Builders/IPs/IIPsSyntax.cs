using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Abstractions.Builders.IPs
{
    public interface IIPsSyntax : IFluentSyntax
    {
        IApiMethod<Api.Entities.IPInformation> Get();
    }
}
