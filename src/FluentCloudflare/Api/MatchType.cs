using FluentCloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Api
{
    public enum MatchType
    {
        All, Any
    }

    internal static class MatchTypeExtensions
    {
        public static string ToApiValue(this MatchType value)
            => value.ToLowerName();
    }
}
