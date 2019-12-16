using Cloudflare.Abstractions.Builders.Dns;
using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Api;
using Cloudflare.Api.Entities;
using Cloudflare.Infrastructure;
using Cloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace Cloudflare.Builders.Dns
{
    internal abstract class ChangeBuilderBase<TBuilderSyntax> : ApiMethod<DnsRecord>
    {
        abstract protected TBuilderSyntax GetThis();

        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        internal ChangeBuilderBase(IRequestBuilderFactory context, DnsRecordType type, string name, string content) : base(context)
        {
            Body.type = type.ToApiValue();
            Body.name = name;
            Body.content = content;
        }

        public TBuilderSyntax Ttl(int seconds)
        {
            Body.ttl = seconds;
            return GetThis();
        }

        /// <summary>
        /// Whether the record is receiving the performance and security benefits of Cloudflare
        /// </summary>
        public TBuilderSyntax Proxied(bool throughCloudflare)
        {
            Body.proxied = throughCloudflare;
            return GetThis();
        }
    }
}
