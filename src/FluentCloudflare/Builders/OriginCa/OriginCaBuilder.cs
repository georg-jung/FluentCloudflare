using FluentCloudflare.Abstractions.Builders.OriginCaCertificates;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace FluentCloudflare.Builders.OriginCaCertificates
{
    internal class OriginCaBuilder : UrlExtendingBuilder, IOriginCaSyntax, IRequestBuilderFactory
    {
        private readonly string originCaKey;

        internal OriginCaBuilder(IRequestBuilderFactory context, string originCaKey) : base(context, "certificates")
        {
            this.originCaKey = originCaKey;
        }

        // curl -X GET "https://api.cloudflare.com/client/v4/certificates/328578533902268680212849205732770752308931942346"
        public IApiMethod<OriginCaCertificate> Get(string certificateSerialNumber)
            => ApiMethod<OriginCaCertificate>.Create(new UrlExtendingBuilder(this, certificateSerialNumber), HttpMethod.Get);

        // curl -X GET "https://api.cloudflare.com/client/v4/certificates?zone_id=023e105f4ecef8ad9ca31a8372d0c353"
        public IApiMethod<List<OriginCaCertificate>> List(string zoneId)
        {
            dynamic prms = new ExpandoObject();
            prms.zone_id = zoneId;
            var meth = ApiMethod<List<OriginCaCertificate>>.Create(this, HttpMethod.Get, prms);
            return meth;
        }

        IRequestBuilder IRequestBuilderFactory.CreateRequestBuilder()
        {
            var builder = base.CreateRequestBuilder();
            builder.Headers["X-Auth-User-Service-Key"] = originCaKey;
            return builder;
        }
    }
}
