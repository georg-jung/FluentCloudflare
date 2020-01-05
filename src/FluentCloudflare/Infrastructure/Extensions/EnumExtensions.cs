using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Infrastructure.Extensions
{
    internal static class EnumExtensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1308:Zeichenfolgen in Großbuchstaben normalisieren", Justification = "This is by design. This method is supposed to be used to match the api specification, which is lower case.")]
        public static string ToLowerName<T>(this T value, IReadOnlyDictionary<string, string> replacements = null) where T : Enum
        {
            var name = Enum.GetName(typeof(T), value).ToLowerInvariant();
            if (replacements != null && replacements.TryGetValue(name, out var replacement))
                return replacement;
            return name;
        }
    }
}
