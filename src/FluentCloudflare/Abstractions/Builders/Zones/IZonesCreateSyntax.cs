using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;

namespace FluentCloudflare.Abstractions.Builders.Zones
{
    public interface IZonesCreateSyntax : IFluentSyntax, IResponseApiMethod<Zone>
    {
        /// <summary>
        /// Automatically attempt to fetch existing DNS records
        /// </summary>
        IZonesCreateSyntax AutoImportDnsRecords(bool jumpStart);

        // missing method: type
        // A full zone implies that DNS is hosted with Cloudflare. A partial zone is typically a partner-hosted zone or a CNAME setup.
    }
}