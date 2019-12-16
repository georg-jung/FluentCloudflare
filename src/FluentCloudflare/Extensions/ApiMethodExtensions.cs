using FluentCloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentCloudflare.Extensions
{
    public static class ApiMethodExtensions
    {
        /// <summary>
        /// Executes an <see cref="IApiMethod{TEntity}"/> using the given <see cref="HttpClient"/>. Afterwards, it ensures the <see cref="Api.Response{TResult}"/> indicates success and returns the contained result of type TEntity.
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity returned by the ApiMethod.</typeparam>
        /// <param name="method">The method to call</param>
        /// <param name="client">The <see cref="HttpClient"/> to perform the request</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> handed over to the HttpClient</param>
        /// <returns>The result contained in the response if the response indicates success, throws otherwise.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="method"/> or <paramref name="client"/> are null.</exception>
        /// <exception cref="CloudflareException">If the response did not indicate success, the StatusCode was not 200 OK or response contained no result.</exception>
        public static async Task<TEntity> CallAsync<TEntity>(this IApiMethod<TEntity> method, HttpClient client, CancellationToken cancellationToken = default)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            return (await method.SendAsync(client, cancellationToken).ConfigureAwait(false)).Unpack();
        }
    }
}
