using Cloudflare.Abstractions.Builders.Dns;
using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Cloudflare.Builders.Dns
{
    internal class UpdateBuilder : ChangeBuilderBase<IDnsUpdateSyntax>, IDnsUpdateSyntax
    {
        /// <inheritdoc/>
        public UpdateBuilder(IRequestBuilderFactory context, DnsRecordType type, string name, string content) : base(context, type, name, content)
        {
            Method = HttpMethod.Put;
        }

        protected override IDnsUpdateSyntax GetThis() => this;
    }
}
