using Cloudflare.Abstractions.Builders;
using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Api;
using Cloudflare.Infrastructure;
using Cloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cloudflare.Builders
{
    public abstract class ListBuilderBase<TBuilder, TEntity> : GetMethod<TEntity>,
        IPaginatedSyntax<TBuilder>, IHasResultFilterStrategySyntax<TBuilder>
    {
        protected dynamic QueryStringParameters { get; } = new ExpandoObject();
        protected IDictionary<string, object> QueryStringParametersDict => (IDictionary<string, object>)QueryStringParameters;
        private protected IRequestBuilderFactory Context { get; }
        abstract private protected int MaximumEntriesPerPage { get; }
        abstract private protected TBuilder GetThis();

        internal ListBuilderBase(IRequestBuilderFactory context)
        {
            Context = context;
        }

        #region "Paging"
        public TBuilder Page(int page)
        {
            if (page < 1)
                throw new ArgumentException($"The page must be bigger than 1.", nameof(page));

            QueryStringParameters.page = page;
            return GetThis();
        }

        public TBuilder PerPage(int maxEntries)
        {
            if (maxEntries < 5 || maxEntries > MaximumEntriesPerPage)
                throw new ArgumentException($"The number of entries per page must be between 5 and {MaximumEntriesPerPage}.", nameof(maxEntries));

            QueryStringParameters.per_page = maxEntries;
            return GetThis();
        }

        public TBuilder OrderBy(string field, OrderDirection direction = OrderDirection.Asc)
        {
            QueryStringParameters.order = field;
            QueryStringParameters.direction = direction.ToApiValue();
            return GetThis();
        }
        #endregion

        public TBuilder Match(MatchType type)
        {
            QueryStringParameters.match = type.ToApiValue();
            return GetThis();
        }

        private protected override IRequestBuilder CreateRequestBuilder()
        {
            var builder = Context.CreateRequestBuilder();
            builder.Method = HttpMethod.Get;
            builder.QueryParameters.SetValues((ExpandoObject)QueryStringParameters);
            return builder;
        }
    }
}
