using Cloudflare.Abstractions.Builders.Dns;
using Cloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Builders.Dns
{
    internal class DnsBuilder : UrlExtendingBuilder, IDnsSyntax
    {
        internal DnsBuilder(IRequestBuilderFactory context) : base(context, "dns_records")
        {
        }

        public IDnsListSyntax List() => new ListBuilder(this);
    }
}
