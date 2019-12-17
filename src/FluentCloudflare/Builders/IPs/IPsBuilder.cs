using FluentCloudflare.Abstractions.Builders.IPs;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FluentCloudflare.Builders.IPs
{
    internal class IPsBuilder : UrlExtender, IIPsSyntax
    {
        internal IPsBuilder(IRequestBuilderFactory context) : base(context, "ips")
        {
        }

        public IResponseApiMethod<Api.Entities.IPInformation> Get() => ResponseApiMethodBuilder<Api.Entities.IPInformation>.Create(this, HttpMethod.Get);
    }
}
