using FluentCloudflare.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentCloudflare.Infrastructure.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        public static async Task<Response<TResultEntity>> CallAsync<TResultEntity>(this HttpRequestMessage request, HttpClient client, CancellationToken cancellationToken = default)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            using var res = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            using var stream = await res.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return stream.DeserializeJson<Response<TResultEntity>>();
        }
    }
}
