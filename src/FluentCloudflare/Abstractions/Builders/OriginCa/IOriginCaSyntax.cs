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
        IResponseApiMethod<List<OriginCaCertificate>> List(string zoneId);
        IResponseApiMethod<OriginCaCertificate> Get(string certificateSerialNumber);
    }
}
