using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Api;
using Cloudflare.Infrastructure;
using Cloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace Cloudflare.Builders.Dns
{
    public class CreateBuilder : IRequestBuilderFactory, IFluentSyntax
    {
        dynamic parameters = new ExpandoObject();
        private readonly IRequestBuilderFactory context;

        internal CreateBuilder(IRequestBuilderFactory context)
        {
            this.context = context;
        }

        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        public CreateBuilder(DnsRecordType type, string name, string content)
        {
            parameters.type = type.ToApiValue();
            parameters.name = name;
            parameters.content = content;
        }

        /// <summary>
        /// Time to live for DNS record. Value of 1 is 'automatic'
        /// </summary>
        public CreateBuilder Ttl(int seconds)
        {
            parameters.ttl = seconds;
            return this;
        }

        /// <summary>
        /// Used with some records like MX and SRV to determine priority. If you do not supply a priority for an MX record, a default value of 0 will be set
        /// </summary>
        /// <param name="priority">0 - 65535</param>
        public CreateBuilder Priority(ushort priority)
        {
            parameters.priority = priority;
            return this;
        }

        /// <summary>
        /// Whether the record is receiving the performance and security benefits of Cloudflare
        /// </summary>
        public CreateBuilder Proxied(bool throughCloudflare)
        {
            parameters.proxied = throughCloudflare;
            return this;
        }

        IRequestBuilder IRequestBuilderFactory.CreateRequestBuilder()
        {
            var builder = context.CreateRequestBuilder();
            builder.Method = HttpMethod.Post;
            builder.Body.SetValues((ExpandoObject)parameters);
            return builder;
        }
    }
}
