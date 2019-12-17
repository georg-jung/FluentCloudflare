using FluentCloudflare.Abstractions.Builders.Dns;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;
using FluentCloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace FluentCloudflare.Builders.Dns
{
    internal class DnsBuilder : UrlExtender, IDnsSyntax
    {
        internal DnsBuilder(IRequestBuilderFactory context) : base(context, "dns_records")
        {
        }

        public IDnsCreateSyntax Create(DnsRecordType type, string name, string content)
            => new CreateBuilder(this, type, name, content);

        public IResponseApiMethod<EntryReference> Delete(string identifier)
            => new UrlExtender(this, identifier)
                .CreateApiMethod<EntryReference>(HttpMethod.Delete);

        public IApiMethod<Stream> Export()
            => new StreamApiMethod(new UrlExtender(this, "export"));

        public IResponseApiMethod<DnsRecord> Get(string identifier)
            => new UrlExtender(this, identifier)
                .CreateApiMethod<DnsRecord>(HttpMethod.Get);

        public IDnsListSyntax List() => new ListBuilder(this);

        public IDnsUpdateSyntax Update(string identifier, DnsRecordType type, string name, string content)
        {
            var ctx = new UrlExtender(this, identifier);
            return new UpdateBuilder(ctx, type, name, content);
        }
    }
}
