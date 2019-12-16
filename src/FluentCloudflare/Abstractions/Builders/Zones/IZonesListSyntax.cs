using FluentCloudflare.Api;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;
using System.Collections.Generic;

namespace FluentCloudflare.Abstractions.Builders.Zones
{
    public interface IZonesListSyntax : IFluentSyntax, IListRequestSyntax<IZonesListSyntax, List<Zone>>
    {
        /// <summary>
        /// A domain name
        /// </summary>
        IZonesListSyntax WithName(string name);

        /// <summary>
        /// Account identifier tag
        /// </summary>
        IZonesListSyntax BelongsTo(string accountId);

        /// <summary>
        /// Account name
        /// </summary>
        IZonesListSyntax BelongsToName(string accountName);

        IZonesListSyntax OrderBy(ZoneOrderKey field, OrderDirection direction = OrderDirection.Asc);
    }
}