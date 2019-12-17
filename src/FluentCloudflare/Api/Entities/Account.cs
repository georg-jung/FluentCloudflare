using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Api.Entities
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public AccountSettings Settings { get; set; }
    }
}
