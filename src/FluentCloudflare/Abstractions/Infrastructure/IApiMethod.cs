using FluentCloudflare.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentCloudflare.Abstractions.Infrastructure
{
    public interface IApiMethod<TEntity>
    {
        Task<Response<TEntity>> SendAsync(HttpClient client, CancellationToken cancellationToken = default);
    }
}
