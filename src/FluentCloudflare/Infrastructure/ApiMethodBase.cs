using FluentCloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentCloudflare.Infrastructure
{
    internal abstract class ApiMethodBase : IApiMethod
    {
        protected abstract IRequestBuilder CreateRequestBuilder();

        public static async Task<HttpResponseMessage> SendAsync(IRequestBuilder requestBuilder, HttpClient client, CancellationToken cancellationToken = default)
        {
            if (requestBuilder == null)
                throw new ArgumentNullException(nameof(requestBuilder));
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            using var req = requestBuilder.Build();
            return await client.SendAsync(req, cancellationToken).ConfigureAwait(false);
        }

        public Task<HttpResponseMessage> SendAsync(HttpClient client, CancellationToken cancellationToken = default)
        {
            var builder = CreateRequestBuilder();
            return SendAsync(builder, client, cancellationToken);
        }
    }
}
