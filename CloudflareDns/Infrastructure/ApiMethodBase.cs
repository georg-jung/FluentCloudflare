using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Api;
using Cloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cloudflare.Infrastructure
{
    public abstract class ApiMethodBase<TEntity> : IRequestBuilderFactory, IApiMethod<TEntity>
    {
        IRequestBuilder IRequestBuilderFactory.CreateRequestBuilder()
            => CreateRequestBuilder();

        private protected abstract IRequestBuilder CreateRequestBuilder();

        public async Task<Response<TEntity>> CallAsync(HttpClient client, CancellationToken cancellationToken = default)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            
            var builder = CreateRequestBuilder();
            using var req = builder.Build();
            using var res = await client.SendAsync(req, cancellationToken).ConfigureAwait(false);

            using var stream = await res.Content.ReadAsStreamAsync().ConfigureAwait(false);
            var resp = stream.DeserializeJson<Response<TEntity>>();
            resp.StatusCode = res.StatusCode;
            return resp;
        }
    }
}
