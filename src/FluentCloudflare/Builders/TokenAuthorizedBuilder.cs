using FluentCloudflare.Abstractions.Builders;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api;
using FluentCloudflare.Infrastructure;
using FluentCloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentCloudflare.Builders
{
    internal class TokenAuthorizedBuilder : AuthorizedBuilder, ITokenAuthorizedSyntax
    {
        internal TokenAuthorizedBuilder(IRequestBuilderFactory context, string token) : base(context, token)
        {
        }

        public IResponseApiMethod<TokenStatus> VerifyToken()
        {
            var builder = new UrlExtender(this, "user", "tokens", "verify");
            return builder.CreateApiMethod<TokenStatus>();
        }
    }
}
