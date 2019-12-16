using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Api
{
    public enum DnsRecordOrderKey
    {
        Type, Name, Content, Ttl, Proxied
    }

    internal static class DnsRecordOrderKeyExtensions
    {
        public static string ToApiValue(this DnsRecordOrderKey value)
            => Enum.GetName(typeof(DnsRecordOrderKey), value).ToLowerInvariant();
    }
}
