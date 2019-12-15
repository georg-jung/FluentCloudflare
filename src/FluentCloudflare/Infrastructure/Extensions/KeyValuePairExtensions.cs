using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Infrastructure.Extensions
{
    internal static class KeyValuePairExtensions
    {
        // from https://github.com/dotnet/roslyn/pull/19126
        // it is available in .Net Core but not in .Net Standard
        public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> keyValuePair, out TKey key, out TValue value)
        {
            key = keyValuePair.Key;
            value = keyValuePair.Value;
        }
    }
}
