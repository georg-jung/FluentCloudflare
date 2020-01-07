using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Abstractions.Builders.Zones
{
    public interface IPurgeCacheSyntax : IFluentSyntax
    {
        IResponseApiMethod<IdResult> Everything();
        IResponseApiMethod<IdResult> ByUrl(params string[] fullQualifiedUrls);
        IResponseApiMethod<IdResult> ByUrl(IEnumerable<string> fullQualifiedUrls);
        IResponseApiMethod<IdResult> ByUrl(IEnumerable<CachedFileToPurge> files);
    }
}
