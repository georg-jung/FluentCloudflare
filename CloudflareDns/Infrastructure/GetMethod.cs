using Cloudflare.Abstractions;
using Cloudflare.Infrastructure.Extensions;
using Cloudflare.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cloudflare.Abstractions.Infrastructure;

namespace Cloudflare.Infrastructure
{
    public abstract class GetMethod<TEntity> : ApiMethod, IGetMethod<TEntity>
    {
        public async Task<Response<TEntity>> GetAsync(HttpClient client, CancellationToken cancellationToken = default)
        {
            var res = await ExecuteAsync(client, cancellationToken).ConfigureAwait(false);
            using var stream = await res.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return stream.DeserializeJson<Response<TEntity>>();
        }
    }
}
