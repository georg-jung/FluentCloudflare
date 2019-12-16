using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Abstractions.Builders.Dns
{
    public interface IDnsChangeSyntax<TISyntax> : IApiMethod<DnsRecord>
    {
        /// <summary>
        /// Time to live for DNS record. Value of 1 is 'automatic'
        /// </summary>
        TISyntax Ttl(int seconds);

        /// <summary>
        /// Whether the record is receiving the performance and security benefits of Cloudflare
        /// </summary>
        TISyntax Proxied(bool throughCloudflare);
    }
}
