using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Api.Entities
{
    public class DnsRecord
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DnsRecordType Type { get; set; }
        public bool Proxiable { get; set; }
        public bool Proxied { get; set; }
        /// <summary>
        /// Time to live for DNS record. Value of 1 is 'automatic'
        /// </summary>
        public int Ttl { get; set; }
        public string ZoneId { get; set; }
        /// <summary>
        /// The domain of the record
        /// </summary>
        public string ZoneName { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Whether this record can be modified/deleted (true means it's managed by Cloudflare)
        /// </summary>
        public bool Locked { get; set; }
        public DnsRecordMeta Meta { get; set; }
    }
}
