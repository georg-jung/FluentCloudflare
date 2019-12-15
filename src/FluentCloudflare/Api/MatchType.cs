using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Api
{
    public enum MatchType
    {
        All, Any
    }

    internal static class MatchTypeExtensions
    {
        public static string ToApiValue(this MatchType value)
            => Enum.GetName(typeof(MatchType), value).ToLowerInvariant();
    }
}
