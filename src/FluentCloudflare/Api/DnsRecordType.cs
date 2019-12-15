using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Api
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DnsRecordType
    {
        A, AAAA, CNAME, TXT, SRV, LOC, MX, NS, SPF, CERT, DNSKEY, DS, NAPTR, SMIMEA, SSHFP, TLSA, URI
    }

    internal static class RecordTypeExtensions
    {
        public static string ToApiValue(this DnsRecordType value)
            => Enum.GetName(typeof(DnsRecordType), value).ToUpperInvariant();
    }
}
