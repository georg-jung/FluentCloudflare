using Cloudflare.Abstractions.Builders;
using Cloudflare.Abstractions.Builders.Zones;
using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Builders.Zones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Builders
{
    public sealed class AuthorizedBuilder : IAuthorizedSyntax, IRequestBuilderFactory
    {
        private readonly IRequestBuilderFactory context;
        private readonly string apiKey;
        private readonly string email;
        private readonly string token;

        internal AuthorizedBuilder(IRequestBuilderFactory context, string token)
        {
            this.context = context;
            this.token = token;
        }

        internal AuthorizedBuilder(IRequestBuilderFactory context, string apiKey, string email)
        {
            this.context = context;
            this.apiKey = apiKey;
            this.email = email;
        }

        IRequestBuilder IRequestBuilderFactory.CreateRequestBuilder()
        {
            var builder = context.CreateRequestBuilder();
            // api keys are more powerful so use one if available
            if (!string.IsNullOrEmpty(apiKey) && !string.IsNullOrEmpty(email))
            {
                builder.Headers["X-Auth-Key"] = apiKey;
                builder.Headers["X-Auth-Email"] = email;
            }
            else
            {
                builder.Headers["Authorization"] = $"Bearer {token}";
            }
            return builder;
        }

        public IZoneSyntax Zone(Api.Entities.Zone zone) => new ZoneBuilder(this, zone?.Id ?? throw new ArgumentNullException(nameof(zone)));

        public IZoneSyntax Zone(string identifier) => new ZoneBuilder(this, identifier);

        public IZonesSyntax Zones => new Zones.ZonesBuilder(this);
    }
}
