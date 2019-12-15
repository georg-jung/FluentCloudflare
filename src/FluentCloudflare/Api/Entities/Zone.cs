using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Api.Entities
{
    public class Zone
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime ActivatedOn { get; set; }
        public Account Account { get; set; }
    }
}
