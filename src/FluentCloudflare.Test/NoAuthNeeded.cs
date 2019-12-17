using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentCloudflare;

namespace FluentCloudflare.Test
{
    public class NoAuthNeeded
    {
        [Fact]
        public async Task TestGetIPs()
        {
            using var hc = new HttpClient();
            var ips = await Cloudflare.IPs.Get().ParseAsync(hc);
            var res = ips.Unpack();
            Assert.Contains(".0/", res.Ipv4Cidrs.First());
            Assert.Contains("::/", res.Ipv6Cidrs.First());
            Assert.True(res.Etag.Length > 8);
            Assert.True(res.Etag.Length < 128);
        }
    }
}
