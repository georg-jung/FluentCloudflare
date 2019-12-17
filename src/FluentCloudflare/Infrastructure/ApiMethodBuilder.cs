using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace FluentCloudflare.Infrastructure
{
    internal class ApiMethodBuilder : ApiMethodBase, IRequestBuilderFactory
    {
        private protected IRequestBuilderFactory Context { get; }
        
        protected dynamic QueryStringParameters { get; } = new ExpandoObject();
        protected IDictionary<string, object> QueryStringParametersDict => (IDictionary<string, object>)QueryStringParameters;

        protected dynamic Body { get; } = new ExpandoObject();
        protected IDictionary<string, object> BodyDict => (IDictionary<string, object>)Body;

        protected Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        protected HttpMethod Method { get; set; }

        internal ApiMethodBuilder(IRequestBuilderFactory context)
        {
            Context = context;
        }

        protected ApiMethodBuilder(IRequestBuilderFactory context, ExpandoObject queryStringParameters, ExpandoObject body) : this(context)
        {
            if (queryStringParameters != null)
                QueryStringParameters = queryStringParameters;
            if (body != null)
                Body = body;
        }

        IRequestBuilder IRequestBuilderFactory.CreateRequestBuilder()
            => CreateRequestBuilder();

        protected override IRequestBuilder CreateRequestBuilder()
        {
            var builder = Context.CreateRequestBuilder();
            builder.Method = Method;
            builder.QueryStringParameters.SetValues((ExpandoObject)QueryStringParameters);
            builder.Body.SetValues((ExpandoObject)Body);
            builder.Headers.SetValues(Headers);
            return builder;
        }

        internal static ApiMethodBuilder Create(IRequestBuilderFactory context, ExpandoObject queryStringParameters = null, ExpandoObject body = null)
            => Create(context, HttpMethod.Get, queryStringParameters, body);

        internal static ApiMethodBuilder Create(
            IRequestBuilderFactory context,
            HttpMethod method,
            ExpandoObject queryStringParameters = null,
            ExpandoObject body = null)
        {
            var meth = new ApiMethodBuilder(context, queryStringParameters, body)
            {
                Method = method
            };
            return meth;
        }
    }
}
