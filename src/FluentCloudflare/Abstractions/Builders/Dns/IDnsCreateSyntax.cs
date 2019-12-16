using Cloudflare.Abstractions.Infrastructure;
using Cloudflare.Api.Entities;
using Cloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Abstractions.Builders.Dns
{
    public interface IDnsCreateSyntax : IFluentSyntax, IDnsChangeSyntax<IDnsCreateSyntax>
    {
        /// <summary>
        /// Used with some records like MX and SRV to determine priority. If you do not supply a priority for an MX record, a default value of 0 will be set
        /// </summary>
        /// <param name="priority">0 - 65535</param>
        IDnsCreateSyntax Priority(ushort priority);
    }
}
