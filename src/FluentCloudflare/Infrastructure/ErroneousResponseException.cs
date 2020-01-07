using FluentCloudflare.Api;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FluentCloudflare.Infrastructure
{
    public class ErroneousResponseException : CloudflareException
    {
        private readonly List<Error> _errors = new List<Error>();
        public IReadOnlyList<Error> Errors => _errors.AsReadOnly();

        public ErroneousResponseException()
        {
        }

        public ErroneousResponseException(string message) : base(message)
        {
        }

        public ErroneousResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ErroneousResponseException(string message, List<Error> errors) : base(message)
        {
            _errors = errors ?? throw new ArgumentNullException(nameof(errors));
        }

        protected ErroneousResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
