using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Infrastructure.Extensions
{
    public static class DictionaryExtensions
    {
        public static void SetValues<TKey, TValue>(this IDictionary<TKey, TValue> target, IReadOnlyDictionary<TKey, TValue> values)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            foreach ((var key, var value) in values)
            {
                target[key] = value;
            }
        }
    }
}
