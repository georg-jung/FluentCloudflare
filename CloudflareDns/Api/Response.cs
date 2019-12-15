using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Api
{
    public class Response<TResult>
    {
        public TResult Result { get; set; }
        public bool Success { get; set; }
        // Errors
        // Messages
        public ResultInfo ResultInfo { get; set; }
    }
}
