using Cloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Builders
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

        IRequestBuilder IRequestBuilderFactory.CreateRequestBuilder()
        {
            var builder = context.CreateRequestBuilder();
            builder.UrlSegments.AddRange(urlExtensions);
            return builder;
        }
    }
}
