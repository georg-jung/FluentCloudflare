using FluentCloudflare.Abstractions.Builders.Dns;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FluentCloudflare.Builders.Dns
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
