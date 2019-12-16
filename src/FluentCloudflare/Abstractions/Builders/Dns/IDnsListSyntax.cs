using FluentCloudflare.Api;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Abstractions.Builders.Dns
{
    public interface IDnsListSyntax : IFluentSyntax, IListRequestSyntax<IDnsListSyntax, List<DnsRecord>>
    {
        /// <summary>
        /// DNS record type
        /// </summary>
        IDnsListSyntax OfType(DnsRecordType type);

        /// <summary>
        /// DNS record name
        /// </summary>
        IDnsListSyntax WithName(string name);

        /// <summary>
        /// DNS record content
        /// </summary>
        IDnsListSyntax WithContent(string content);

        /// <param name="field">Field to order records by</param>
        /// <param name="direction">Direction to order domains</param>
        IDnsListSyntax OrderBy(DnsRecordOrderKey field, OrderDirection direction = OrderDirection.Asc);
    }
}
