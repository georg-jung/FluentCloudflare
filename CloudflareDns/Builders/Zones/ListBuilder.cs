using Cloudflare.Abstractions.Builders.Zones;
using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Api;
using Cloudflare.Api.Entities;
using Cloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace Cloudflare.Builders.Zones
{
    internal class ListBuilder : ListBuilderBase<IZonesListSyntax, List<Zone>>, IZonesListSyntax
    {
        private protected override int MaximumEntriesPerPage => 50;

        private protected override IZonesListSyntax GetThis() => this;

        internal ListBuilder(IRequestBuilderFactory context) : base(context)
        {
        }

        /// <summary>
        /// A domain name
        /// </summary>
        public IZonesListSyntax WithName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(name);
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("This parameter can not be empty or contain only whitespace.", nameof(name));
            if (name.Length > 253)
                throw new ArgumentException("This parameter can not be longer than 253 characters.", nameof(name));

            QueryStringParameters.name = name;
            return this;
        }

        /// <summary>
        /// Account identifier tag
        /// </summary>
        public IZonesListSyntax BelongsTo(string accountId)
        {
            if (accountId == null)
                throw new ArgumentNullException(accountId);
            if (string.IsNullOrWhiteSpace(accountId))
                throw new ArgumentException("This parameter can not be empty or contain only whitespace.", nameof(accountId));
            if (accountId.Length > 32)
                throw new ArgumentException("This parameter can not be longer than 32 characters.", nameof(accountId));

            QueryStringParametersDict["account.id"] = accountId;
            return this;
        }

        /// <summary>
        /// Account name
        /// </summary>
        public IZonesListSyntax BelongsToName(string accountName)
        {
            if (accountName == null)
                throw new ArgumentNullException(accountName);
            if (string.IsNullOrWhiteSpace(accountName))
                throw new ArgumentException("This parameter can not be empty or contain only whitespace.", nameof(accountName));
            if (accountName.Length > 100)
                throw new ArgumentException("This parameter can not be longer than 100 characters.", nameof(accountName));

            QueryStringParametersDict["account.name"] = accountName;
            return this;
        }

        public IZonesListSyntax OrderBy(ZoneOrderKey field, OrderDirection direction = OrderDirection.Asc)
            => OrderBy(field.ToApiValue(), direction);
    }
}
