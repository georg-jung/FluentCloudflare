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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1308:Zeichenfolgen in Großbuchstaben normalisieren", Justification = "This isn't an internal normalization; it's made to match the api specification, which is lower case.")]
        public static string ToApiValue(this MatchType value)
            => Enum.GetName(typeof(MatchType), value).ToLowerInvariant();
    }
}
