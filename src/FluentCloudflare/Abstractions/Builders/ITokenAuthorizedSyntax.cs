using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentCloudflare.Abstractions.Builders
{
    public interface ITokenAuthorizedSyntax : IAuthorizedSyntax
    {
        IResponseApiMethod<TokenStatus> VerifyToken();
    }
}
