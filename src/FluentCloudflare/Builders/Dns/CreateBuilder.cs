using Cloudflare.Abstractions.Builders.Dns;
using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Api;
using Cloudflare.Api.Entities;
using Cloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Cloudflare.Builders.Dns
{
    internal class CreateBuilder : ChangeBuilderBase<IDnsCreateSyntax>, IDnsCreateSyntax
    {        
        /// <inheritdoc/>
        public CreateBuilder(IRequestBuilderFactory context, DnsRecordType type, string name, string content) : base(context, type, name, content)
        {
            Method = HttpMethod.Post;
        }

        public IDnsCreateSyntax Priority(ushort priority)
        {
            Body.priority = priority;
            return GetThis();
        }


        protected override IDnsCreateSyntax GetThis() => this;
    }
}
