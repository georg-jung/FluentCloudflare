using Cloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cloudflare.Infrastructure
{
    public abstract class ApiMethod : IRequestBuilderFactory
    {
        IRequestBuilder IRequestBuilderFactory.CreateRequestBuilder()
            => CreateRequestBuilder();

        private protected abstract IRequestBuilder CreateRequestBuilder();

        protected async Task<HttpResponseMessage> ExecuteAsync(HttpClient client, CancellationToken cancellationToken = default)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            var builder = CreateRequestBuilder();
            var req = builder.Build();
            return await client.SendAsync(req, cancellationToken).ConfigureAwait(false);
        }
    }
}
