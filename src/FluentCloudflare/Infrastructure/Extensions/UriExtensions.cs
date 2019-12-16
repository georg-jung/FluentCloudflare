using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FluentCloudflare.Infrastructure.Extensions
{
    public static class UriExtensions
    {
        public static Uri Append(this Uri uri, params string[] paths) => Append(uri, (IEnumerable<string>)paths);

        public static Uri Append(this Uri uri, IEnumerable<string> paths)
        {
            // based on https://stackoverflow.com/a/7993235/1200847
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));
            return new Uri(paths.Aggregate(uri.AbsoluteUri, (current, path) => string.Format(CultureInfo.InvariantCulture, "{0}/{1}", current.TrimEnd('/'), path.TrimStart('/'))));
        }
    }
}
