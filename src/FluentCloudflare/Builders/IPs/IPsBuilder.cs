using Cloudflare.Abstractions.Builders.IPs;
using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Cloudflare.Builders.IPs
{
    internal class IPsBuilder : UrlExtendingBuilder, IIPsSyntax
    {
        internal IPsBuilder(IRequestBuilderFactory context) : base(context, "ips")
        {
        }

        public IApiMethod<Api.Entities.IPInformation> Get() => ApiMethod<Api.Entities.IPInformation>.Create(this, HttpMethod.Get);
    }
}
