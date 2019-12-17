using FluentCloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace FluentCloudflare.Infrastructure.Extensions
{
    internal static class IRequestBuilderFactoryExtensions
    {
        public static ResponseApiMethodBuilder<TEntity> CreateApiMethod<TEntity>(
            this IRequestBuilderFactory factory,
            HttpMethod method,
            ExpandoObject queryStringParameters = null)
        => ResponseApiMethodBuilder<TEntity>.Create(factory, method, queryStringParameters);
    }
}
