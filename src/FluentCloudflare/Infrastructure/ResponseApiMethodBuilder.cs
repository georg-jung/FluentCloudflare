using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentCloudflare.Infrastructure
{
    internal class ResponseApiMethodBuilder<TEntity> : ApiMethodBuilder, IResponseApiMethod<TEntity>
    {
        internal ResponseApiMethodBuilder(IRequestBuilderFactory context) : base(context)
        {
        }

        private ResponseApiMethodBuilder(IRequestBuilderFactory context, ExpandoObject queryStringParameters, ExpandoObject body) : base(context, queryStringParameters, body)
        {
        }

        public async Task<Response<TEntity>> ParseAsync(HttpClient client, CancellationToken cancellationToken = default)
        {
            using var res = await SendAsync(client, cancellationToken).ConfigureAwait(false);
            return await ResponseApiMethod<TEntity>.ParseAsync(res).ConfigureAwait(false);
        }

        internal static new ResponseApiMethodBuilder<TEntity> Create(IRequestBuilderFactory context, ExpandoObject queryStringParameters = null, ExpandoObject body = null)
            => Create(context, HttpMethod.Get, queryStringParameters, body);

        internal static new ResponseApiMethodBuilder<TEntity> Create(
            IRequestBuilderFactory context,
            HttpMethod method,
            ExpandoObject queryStringParameters = null,
            ExpandoObject body = null)
        {
            var meth = new ResponseApiMethodBuilder<TEntity>(context, queryStringParameters, body)
            {
                Method = method
            };
            return meth;
        }
    }
}
