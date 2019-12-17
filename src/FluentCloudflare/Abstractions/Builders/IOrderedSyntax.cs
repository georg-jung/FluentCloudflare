using FluentCloudflare.Api;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Abstractions.Builders
{
    public interface IOrderedSyntax<TBuilder> : IFluentSyntax
    {
        /// <param name="field">Field to order records by</param>
        /// <param name="direction">Direction to order</param>
        TBuilder OrderBy(string field, OrderDirection direction = OrderDirection.Asc);
    }
}
