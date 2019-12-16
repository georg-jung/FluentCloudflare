using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Api.Entities
{
    public class IPInformation
    {
        public List<string> Ipv4Cidrs { get; set; }
        public List<string> Ipv6Cidrs { get; set; }
        public string Etag { get; set; }
    }
}
