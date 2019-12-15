using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Api.Entities;
using Cloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Abstractions.Builders.Dns
{
    public interface IDnsCreateSyntax : IFluentSyntax, IApiMethod<DnsRecord>
    {
        /// <summary>
        /// Time to live for DNS record. Value of 1 is 'automatic'
        /// </summary>
        IDnsCreateSyntax Ttl(int seconds);

        /// <summary>
        /// Used with some records like MX and SRV to determine priority. If you do not supply a priority for an MX record, a default value of 0 will be set
        /// </summary>
        /// <param name="priority">0 - 65535</param>
        IDnsCreateSyntax Priority(ushort priority);

        /// <summary>
        /// Whether the record is receiving the performance and security benefits of Cloudflare
        /// </summary>
        IDnsCreateSyntax Proxied(bool throughCloudflare);
    }
}
