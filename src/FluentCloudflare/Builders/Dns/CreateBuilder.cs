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
    internal class CreateBuilder : ApiMethod<DnsRecord>, IDnsCreateSyntax
    {
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        public CreateBuilder(IRequestBuilderFactory context, DnsRecordType type, string name, string content) : base(context)
        {
            Method = HttpMethod.Post;
            Body.type = type.ToApiValue();
            Body.name = name;
            Body.content = content;
        }

        public IDnsCreateSyntax Ttl(int seconds)
        {
            Body.ttl = seconds;
            return this;
        }

        public IDnsCreateSyntax Priority(ushort priority)
        {
            Body.priority = priority;
            return this;
        }

        /// <summary>
        /// Whether the record is receiving the performance and security benefits of Cloudflare
        /// </summary>
        public IDnsCreateSyntax Proxied(bool throughCloudflare)
        {
            Body.proxied = throughCloudflare;
            return this;
        }
    }
}
