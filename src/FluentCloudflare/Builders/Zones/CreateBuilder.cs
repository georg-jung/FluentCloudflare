using FluentCloudflare.Abstractions.Builders.Zones;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;
using System.Dynamic;
using System.Net.Http;

namespace FluentCloudflare.Builders.Zones
{
    internal class CreateBuilder : ResponseApiMethodBuilder<Zone>, IZonesCreateSyntax
    {
        internal CreateBuilder(IRequestBuilderFactory context, string domainName, string accountId) : base(context)
        {
            Method = HttpMethod.Post;
            dynamic account = new ExpandoObject();
            account.id = accountId;
            Body.name = domainName;
            Body.account = account;
        }

        public IZonesCreateSyntax AutoImportDnsRecords(bool jumpStart)
        {
            Body.jump_start = jumpStart;
            return this;
        }
    }
}