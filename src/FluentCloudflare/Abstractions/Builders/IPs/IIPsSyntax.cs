﻿using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Abstractions.Builders.IPs
{
    public interface IIPsSyntax : IFluentSyntax
    {
        IResponseApiMethod<Api.Entities.IPInformation> Get();
    }
}
