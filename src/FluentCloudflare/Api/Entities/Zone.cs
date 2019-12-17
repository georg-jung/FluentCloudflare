using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Api.Entities
{
    public class Zone
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime? ActivatedOn { get; set; }
        public Account Account { get; set; }
        public string OriginalRegistrar { get; set; }
        public string OriginalDnshost { get; set; }
        public bool Paused { get; set; }
        public List<string> NameServers { get; set; }
        public List<string> OriginalNameServers { get; set; }
        public int DevelopmentMode { get; set; }
    }
}
