using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace FluentCloudflare.Infrastructure
{
    internal class ApiMethod<TEntity> : ApiMethodBase<TEntity>
    {
        private protected IRequestBuilderFactory Context { get; }
        
        protected dynamic QueryStringParameters { get; } = new ExpandoObject();
        protected IDictionary<string, object> QueryStringParametersDict => (IDictionary<string, object>)QueryStringParameters;

        protected dynamic Body { get; } = new ExpandoObject();
        protected IDictionary<string, object> BodyDict => (IDictionary<string, object>)Body;

        protected Dictionary<string, string> Headers { get; } = new Dictionary<string, string>();

        protected HttpMethod Method { get; set; }

        internal ApiMethod(IRequestBuilderFactory context)
        {
            Context = context;
        }

        private ApiMethod(IRequestBuilderFactory context, ExpandoObject queryStringParameters) : this(context)
        {
            if (queryStringParameters != null)
                QueryStringParameters = queryStringParameters;
        }

        private protected override IRequestBuilder CreateRequestBuilder()
        {
            var builder = Context.CreateRequestBuilder();
            builder.Method = Method;
            builder.QueryStringParameters.SetValues((ExpandoObject)QueryStringParameters);
            builder.Body.SetValues((ExpandoObject)Body);
            builder.Headers.SetValues(Headers);
            return builder;
        }

        internal static ApiMethod<TEntity> Create(IRequestBuilderFactory context, HttpMethod method, ExpandoObject queryStringParameters = null)
        {
            var meth = new ApiMethod<TEntity>(context, queryStringParameters)
            {
                Method = method
            };
            return meth;
        }
    }
}
