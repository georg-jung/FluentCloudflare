using FluentCloudflare.Abstractions.Builders.Zones;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api;
using FluentCloudflare.Infrastructure;
using FluentCloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace FluentCloudflare.Builders.Zones
{
    internal class PurgeCacheBuilder : UrlExtender, IPurgeCacheSyntax
    {
        internal PurgeCacheBuilder(IRequestBuilderFactory context) : base(context, "purge_cache")
        {
        }

        public IResponseApiMethod<IdResult> ByUrl(IEnumerable<CachedFileToPurge> files)
        {
            dynamic body = new ExpandoObject();
            body.files = files;
            return this.CreateApiMethod<IdResult>(HttpMethod.Post, body: (ExpandoObject)body);
        }

        public IResponseApiMethod<IdResult> ByUrl(IEnumerable<string> fullQualifiedUrls)
        {
            dynamic body = new ExpandoObject();
            body.files = fullQualifiedUrls;
            return this.CreateApiMethod<IdResult>(HttpMethod.Post, body: (ExpandoObject)body);
        }

        public IResponseApiMethod<IdResult> ByUrl(params string[] fullQualifiedUrls) => ByUrl((IEnumerable<string>)fullQualifiedUrls);

        public IResponseApiMethod<IdResult> Everything()
        {
            dynamic body = new ExpandoObject();
            body.purge_everything = true;
            return this.CreateApiMethod<IdResult>(HttpMethod.Post, body: (ExpandoObject)body);
        }
    }
}
