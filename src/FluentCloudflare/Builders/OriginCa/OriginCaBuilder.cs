﻿using FluentCloudflare.Abstractions.Builders.OriginCaCertificates;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;
using FluentCloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace FluentCloudflare.Builders.OriginCaCertificates
{
    internal class OriginCaBuilder : UrlExtender, IOriginCaSyntax, IRequestBuilderFactory
    {
        private readonly string originCaKey;

        internal OriginCaBuilder(IRequestBuilderFactory context, string originCaKey) : base(context, "certificates")
        {
            this.originCaKey = originCaKey;
        }

        // curl -X GET "https://api.cloudflare.com/client/v4/certificates/328578533902268680212849205732770752308931942346"
        public IResponseApiMethod<OriginCaCertificate> Get(string certificateSerialNumber)
            => ResponseApiMethodBuilder<OriginCaCertificate>.Create(new UrlExtender(this, certificateSerialNumber));

        // curl -X GET "https://api.cloudflare.com/client/v4/certificates?zone_id=023e105f4ecef8ad9ca31a8372d0c353"
        public IResponseApiMethod<List<OriginCaCertificate>> List(string zoneId)
        {
            dynamic prms = new ExpandoObject();
            prms.zone_id = zoneId;
            return this.CreateApiMethod<List<OriginCaCertificate>>(queryStringParameters: (ExpandoObject)prms);
        }

        IRequestBuilder IRequestBuilderFactory.CreateRequestBuilder()
        {
            var builder = base.CreateRequestBuilder();
            builder.Headers["X-Auth-User-Service-Key"] = originCaKey;
            return builder;
        }
    }
}
