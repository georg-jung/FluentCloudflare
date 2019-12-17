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
            ExpandoObject queryStringParameters = null,
            ExpandoObject body = null)
        => ResponseApiMethodBuilder<TEntity>.Create(factory, method, queryStringParameters, body);
        
        public static ResponseApiMethodBuilder<TEntity> CreateApiMethod<TEntity>(
            this IRequestBuilderFactory factory,
            ExpandoObject queryStringParameters = null,
            ExpandoObject body = null)
        => ResponseApiMethodBuilder<TEntity>.Create(factory, queryStringParameters, body);

        public static ApiMethodBuilder CreateApiMethod(
            this IRequestBuilderFactory factory,
            HttpMethod method,
            ExpandoObject queryStringParameters = null,
            ExpandoObject body = null)
            => ApiMethodBuilder.Create(factory, method, queryStringParameters, body);

        public static ApiMethodBuilder CreateApiMethod(
            this IRequestBuilderFactory factory,
            ExpandoObject queryStringParameters = null,
            ExpandoObject body = null)
            => ApiMethodBuilder.Create(factory, queryStringParameters, body);
    }
}
