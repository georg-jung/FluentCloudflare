using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Api;
using Cloudflare.Api.Entities;
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

        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        IDnsCreateSyntax Create(DnsRecordType type, string name, string content);

        /// <param name="identifier">The identifier of the record as determined by <see cref="Get(string)"/> or <see cref="List"/>.</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        IDnsUpdateSyntax Update(string identifier, DnsRecordType type, string name, string content);

        IApiMethod<EntryReference> Delete(string identifier);

        IApiMethod<DnsRecord> Get(string identifier);
    }
}
