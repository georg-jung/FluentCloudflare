using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Infrastructure.Extensions
{
    internal static class EnumExtensions
    {
        public static string ToName<T>(this T value, IReadOnlyDictionary<string, string> replacements = null) where T : Enum
        {
            var name = Enum.GetName(typeof(T), value).ToLowerInvariant();
            if (replacements != null && replacements.TryGetValue(name, out var replacement))
                return replacement;
            return name;
        }
    }
}
