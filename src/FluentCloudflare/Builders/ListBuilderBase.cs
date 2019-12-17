using FluentCloudflare.Abstractions.Builders;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api;
using FluentCloudflare.Infrastructure;
using FluentCloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FluentCloudflare.Builders
{
    internal abstract class ListBuilderBase<TBuilderSyntax, TEntity> : 
        ResponseApiMethodBuilder<List<TEntity>>,
        IPaginatedSyntax<TBuilderSyntax>,
        IOrderedSyntax<TBuilderSyntax>,
        IHasResultFilterStrategySyntax<TBuilderSyntax>
    {
        public int MaximumEntriesPerPage { get; }
        abstract protected TBuilderSyntax GetThis();

        internal ListBuilderBase(IRequestBuilderFactory context, int maximumEntriesPerPage) : base(context)
        {
            Method = HttpMethod.Get;
            MaximumEntriesPerPage = maximumEntriesPerPage;
        }

        #region "Paging"
        public TBuilderSyntax Page(int page)
        {
            if (page < 1)
                throw new ArgumentException($"The page must be bigger than 1.", nameof(page));

            QueryStringParameters.page = page;
            return GetThis();
        }

        public TBuilderSyntax PerPage(int maxEntries)
        {
            if (maxEntries < 5 || maxEntries > MaximumEntriesPerPage)
                throw new ArgumentException($"The number of entries per page must be between 5 and {MaximumEntriesPerPage}.", nameof(maxEntries));

            QueryStringParameters.per_page = maxEntries;
            return GetThis();
        }

        public TBuilderSyntax OrderBy(string field, OrderDirection direction = OrderDirection.Asc)
        {
            QueryStringParameters.order = field;
            QueryStringParameters.direction = direction.ToApiValue();
            return GetThis();
        }
        #endregion

        public TBuilderSyntax Match(MatchType type)
        {
            QueryStringParameters.match = type.ToApiValue();
            return GetThis();
        }
    }
}
