using Cloudflare.Builders.Dns;
using Cloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Abstractions.Builders.Dns
{
    public interface IDnsSyntax : IFluentSyntax
    {
        IDnsListSyntax List();
    }
}
