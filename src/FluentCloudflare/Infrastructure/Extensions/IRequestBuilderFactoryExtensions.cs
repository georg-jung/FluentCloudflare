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
        public static ApiMethod<TEntity> CreateApiMethod<TEntity>(
            this IRequestBuilderFactory factory,
            HttpMethod method,
            ExpandoObject queryStringParameters = null)
        => ApiMethod<TEntity>.Create(factory, method, queryStringParameters);
    }
}
