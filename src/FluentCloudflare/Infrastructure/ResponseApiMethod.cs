using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api;
using FluentCloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentCloudflare.Infrastructure
{
    internal class ResponseApiMethod<TEntity> : ApiMethod, IApiMethod<Response<TEntity>>
    {
        internal ResponseApiMethod(IRequestBuilder requestBuilder) : base(requestBuilder)
        {
        }

        internal ResponseApiMethod(IRequestBuilderFactory factory) : base(factory)
        {
        }

        internal ResponseApiMethod(Func<IRequestBuilder> builderFactory) : base(builderFactory)
        {
        }

        public static async Task<Response<TEntity>> ParseAsync(HttpResponseMessage res)
        {
            using var stream = await res.Content.ReadAsStreamAsync().ConfigureAwait(false);
            var resp = stream.DeserializeJson<Response<TEntity>>();
            resp.StatusCode = res.StatusCode;
            return resp;
        }

        public async Task<Response<TEntity>> ParseAsync(HttpClient client, CancellationToken cancellationToken = default)
        {
            using var res = await SendAsync(client, cancellationToken).ConfigureAwait(false);
            return await ParseAsync(res).ConfigureAwait(false);
        }
    }
}
