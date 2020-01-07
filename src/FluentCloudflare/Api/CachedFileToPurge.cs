using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Api
{
    public class CachedFileToPurge
    {
        public CachedFileToPurge(string url)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }

        public CachedFileToPurge(Uri url) : this(url?.AbsoluteUri)
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1056:URI-Eigenschaften dürfen keine Zeichenfolgen sein", Justification = "This should be a string as the API takes a string")]
        public string Url { get; }

        public Dictionary<string, string> Headers { get; } = new Dictionary<string, string>();

        private const string _cacheKeyDeviceTypeHeader = "CF-Device-Type";
        [JsonIgnore]
        public string CacheKeyDeviceType
        {
            get
            {
                if (Headers.TryGetValue(_cacheKeyDeviceTypeHeader, out var val))
                    return val;
                return null;
            }
            set
            {
                if (value == null)
                    Headers.Remove(_cacheKeyDeviceTypeHeader);
                else Headers[_cacheKeyDeviceTypeHeader] = value;
            }
        }

        private const string _cacheKeyIpCountryHeader = "CF-IPCountry";
        [JsonIgnore]
        public string CacheKeyIpCountry
        {
            get
            {
                if (Headers.TryGetValue(_cacheKeyIpCountryHeader, out var val))
                    return val;
                return null;
            }
            set
            {
                if (value == null)
                    Headers.Remove(_cacheKeyIpCountryHeader);
                else Headers[_cacheKeyIpCountryHeader] = value;
            }
        }
    }
}
