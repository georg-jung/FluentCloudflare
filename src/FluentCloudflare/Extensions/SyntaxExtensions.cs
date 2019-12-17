using FluentCloudflare.Abstractions.Builders.Dns;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api;
using FluentCloudflare.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Extensions
{
    public static class SyntaxExtensions
    {
        public static IDnsUpdateSyntax Update(this IDnsSyntax syntax, DnsRecord record, DnsRecordType type, string name, string content)
            => syntax.Update(record.Id, type, name, content);

        public static IResponseApiMethod<EntryReference> Delete(this IDnsSyntax syntax, DnsRecord record)
            => syntax.Delete(record.Id);
    }
}
