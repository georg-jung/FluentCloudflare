using Cloudflare.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cloudflare.Abstractions.Infrastructure
{
    public interface IGetMethod<TEntity>
    {
        Task<Response<TEntity>> GetAsync(HttpClient client, CancellationToken cancellationToken = default);
    }
}
