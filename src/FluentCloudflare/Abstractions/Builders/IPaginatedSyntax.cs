using FluentCloudflare.Api;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Abstractions.Builders
{
    public interface IPaginatedSyntax<TBuilder> : IFluentSyntax
    {
        /// <summary>
        /// Page number of paginated results
        /// </summary>
        TBuilder Page(int page);

        /// <summary>
        /// Number of entries per page
        /// </summary>
        TBuilder PerPage(int maxEntries);

        /// <param name="field">Field to order records by</param>
        /// <param name="direction">Direction to order</param>
        TBuilder OrderBy(string field, OrderDirection direction = OrderDirection.Asc);
    }
}
