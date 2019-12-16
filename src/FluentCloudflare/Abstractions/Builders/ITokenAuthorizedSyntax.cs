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
        Task<Response<TokenStatus>> VerifyToken(HttpClient client, CancellationToken cancellationToken = default);
    }
}
