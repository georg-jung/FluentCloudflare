using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Abstractions.Builders.OriginCaCertificates
{
    public interface IOriginCaSyntax : IFluentSyntax
    {
        IApiMethod<List<OriginCaCertificate>> List(string zoneId);
        IApiMethod<OriginCaCertificate> Get(string certificateSerialNumber);
    }
}
