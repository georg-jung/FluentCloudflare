using FluentCloudflare.Infrastructure.Extensions;
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
            => value.ToLowerName();
    }
}
