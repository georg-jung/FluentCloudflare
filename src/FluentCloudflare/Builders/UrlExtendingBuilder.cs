using FluentCloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Builders
{
    internal class UrlExtendingBuilder : IRequestBuilderFactory
    {
        private readonly IRequestBuilderFactory context;
        private readonly IEnumerable<string> urlExtensions;

        internal UrlExtendingBuilder(IRequestBuilderFactory context, params string[] urlExtensions)
            : this(context, (IEnumerable<string>)urlExtensions)
        {
        }

        internal UrlExtendingBuilder(IRequestBuilderFactory context, IEnumerable<string> urlExtensions)
        {
            this.context = context;
            this.urlExtensions = urlExtensions;
        }

        private protected IRequestBuilder CreateRequestBuilder()
        {
            var builder = context.CreateRequestBuilder();
            builder.UrlSegments.AddRange(urlExtensions);
            return builder;
        }

        IRequestBuilder IRequestBuilderFactory.CreateRequestBuilder() => CreateRequestBuilder();
    }
}
