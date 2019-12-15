using Cloudflare.Abstractions.Builders;
using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Api;
using Cloudflare.Infrastructure;
using Cloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cloudflare.Builders
{
    internal class TokenAuthorizedBuilder : AuthorizedBuilder, ITokenAuthorizedSyntax
    {
        internal TokenAuthorizedBuilder(IRequestBuilderFactory context, string token) : base(context, token)
        {
        }

        public async Task<Response<TokenStatus>> VerifyToken(HttpClient client, CancellationToken cancellationToken = default)
        {
            return await (new VerifyTokenBuilder(this)).CallAsync(client, cancellationToken).ConfigureAwait(false);
        }

        private class VerifyTokenBuilder : ApiMethodBase<TokenStatus>
        {
            private readonly IRequestBuilderFactory context;

            public VerifyTokenBuilder(IRequestBuilderFactory context)
            {
                this.context = new UrlExtendingBuilder(context, "user", "tokens", "verify");
            }

            private protected override IRequestBuilder CreateRequestBuilder() => context.CreateRequestBuilder();
        }
    }
}
