using Cloudflare.Abstractions.Builders.Dns;
using Cloudflare.Api;
using Cloudflare.Api.Entities;
using Cloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using Cloudflare.Abstractions.Infrastructure;

namespace Cloudflare.Builders.Dns
{
    internal class ListBuilder : ListBuilderBase<IDnsListSyntax, List<DnsRecord>>, IDnsListSyntax
    {
        private protected override int MaximumEntriesPerPage => 100;

        private protected override IDnsListSyntax GetThis() => this;

        internal ListBuilder(IRequestBuilderFactory context) : base(context)
        {
        }

        public IDnsListSyntax OfType(DnsRecordType type)
        {
            QueryStringParameters.type = type.ToApiValue();
            return this;
        }

        public IDnsListSyntax WithName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(name);
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("This parameter can not be empty or contain only whitespace.", nameof(name));
            if (name.Length > 255)
                throw new ArgumentException("This parameter can not be longer than 255 characters.", nameof(name));

            QueryStringParameters.name = name;
            return this;
        }

        public IDnsListSyntax WithContent(string content)
        {
            QueryStringParameters.content = content ?? throw new ArgumentNullException(nameof(content));
            return this;
        }

        public IDnsListSyntax OrderBy(DnsRecordOrderKey field, OrderDirection direction = OrderDirection.Asc)
            => OrderBy(field.ToApiValue(), direction);
    }
}
