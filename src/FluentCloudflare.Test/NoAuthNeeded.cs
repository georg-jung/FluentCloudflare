using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CF = Cloudflare;

namespace FluentCloudflare.Test
{
    public class NoAuthNeeded
    {
        [Fact]
        public async Task TestGetIPs()
        {
            using var hc = new HttpClient();
            var ips = await CF.Cloudflare.IPs.Get().CallAsync(hc);
            var res = ips.Unpack();
            Assert.Contains(".0/", res.Ipv4Cidrs.First());
            Assert.Contains("::/", res.Ipv6Cidrs.First());
            Assert.True(res.Etag.Length > 8);
            Assert.True(res.Etag.Length < 128);
        }
    }
}
