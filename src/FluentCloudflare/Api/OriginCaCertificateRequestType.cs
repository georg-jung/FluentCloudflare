using FluentCloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FluentCloudflare.Api
{
    public enum OriginCaCertificateRequestType
    {
        [EnumMember(Value = "origin-rsa")]
        OriginRsa,
        [EnumMember(Value = "origin-ecc")]
        OriginEcc,
        [EnumMember(Value = "keyless-certificate")]
        KeylessCertificate
    }
}
