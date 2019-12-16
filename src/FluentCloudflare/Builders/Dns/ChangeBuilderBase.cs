using FluentCloudflare.Abstractions.Builders.Dns;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;
using FluentCloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace FluentCloudflare.Builders.Dns
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
