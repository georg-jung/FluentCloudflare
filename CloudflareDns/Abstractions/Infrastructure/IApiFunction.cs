using Cloudflare.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cloudflare.Abstractions.Infrastructure
{
    public interface IApiMethod<TEntity>
    {
        Task<Response<TEntity>> CallAsync(HttpClient client, CancellationToken cancellationToken = default);
    }
}
