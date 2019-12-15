using Cloudflare.Abstractions.Builders.Dns;
using Cloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Builders.Dns
{
    internal class DnsBuilder : IDnsSyntax, IRequestBuilderFactory
    {
        private readonly IRequestBuilderFactory context;

        internal DnsBuilder(IRequestBuilderFactory context)
        {
            this.context = context;
        }

        public IDnsListSyntax List() => new ListBuilder(this);

        IRequestBuilder IRequestBuilderFactory.CreateRequestBuilder()
        {
            var builder = context.CreateRequestBuilder();
            builder.UrlSegments.Add("dns_records");
            return builder;
        }
    }
}
