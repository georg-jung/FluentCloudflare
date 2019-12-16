using Cloudflare.Abstractions.Builders.Dns;
using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Api;
using Cloudflare.Api.Entities;
using Cloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Cloudflare.Builders.Dns
{
    internal class DnsBuilder : UrlExtendingBuilder, IDnsSyntax
    {
        internal DnsBuilder(IRequestBuilderFactory context) : base(context, "dns_records")
        {
        }

        public IDnsCreateSyntax Create(DnsRecordType type, string name, string content)
            => new CreateBuilder(this, type, name, content);

        public IApiMethod<EntryReference> Delete(string identifier)
            => new UrlExtendingBuilder(this, identifier)
                .CreateApiMethod<EntryReference>(HttpMethod.Delete);

        public IApiMethod<DnsRecord> Get(string identifier)
        => new UrlExtendingBuilder(this, identifier)
                .CreateApiMethod<DnsRecord>(HttpMethod.Get);

        public IDnsListSyntax List() => new ListBuilder(this);

        public IDnsUpdateSyntax Update(string identifier, DnsRecordType type, string name, string content)
        {
            var ctx = new UrlExtendingBuilder(this, identifier);
            return new UpdateBuilder(ctx, type, name, content);
        }
    }
}
