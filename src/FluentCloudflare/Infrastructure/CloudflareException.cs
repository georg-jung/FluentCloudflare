using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FluentCloudflare.Infrastructure
{
    public class CloudflareException : Exception
    {
        public CloudflareException()
        {
        }

        public CloudflareException(string message) : base(message)
        {
        }

        public CloudflareException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CloudflareException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
