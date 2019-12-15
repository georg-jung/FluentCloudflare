using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Api
{
    public class ResultInfo
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
    }
}
