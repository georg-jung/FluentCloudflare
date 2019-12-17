using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api;
using FluentCloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentCloudflare.Infrastructure
{
    internal class ApiMethod : ApiMethodBase
    {
        private readonly IRequestBuilder requestBuilder;
        private readonly Func<IRequestBuilder> builderFactory;

        internal ApiMethod(IRequestBuilder requestBuilder)
        {
            this.requestBuilder = requestBuilder;
        }

        internal ApiMethod(IRequestBuilderFactory factory) : this(factory.CreateRequestBuilder)
        {
        }

        internal ApiMethod(Func<IRequestBuilder> builderFactory)
        {
            this.builderFactory = builderFactory;
        }

        protected override IRequestBuilder CreateRequestBuilder()
            => requestBuilder ?? builderFactory();
    }
}
