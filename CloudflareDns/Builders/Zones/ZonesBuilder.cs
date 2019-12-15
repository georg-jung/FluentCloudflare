using Cloudflare.Abstractions.Builders;
using Cloudflare.Abstractions.Builders.Zones;
using Cloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Builders.Zones
{
    public class ZonesBuilder : IZonesSyntax, IRequestBuilderFactory
    {
        private readonly IRequestBuilderFactory context;

        internal ZonesBuilder(IRequestBuilderFactory context)
        {
            this.context = context;
        }

        public IZonesListSyntax List() => new ListBuilder(this);

        IRequestBuilder IRequestBuilderFactory.CreateRequestBuilder()
        {
            var builder = context.CreateRequestBuilder();
            builder.UrlSegments.Add("zones");
            return builder;
        }
    }
}
