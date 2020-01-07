using FluentCloudflare.Api;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FluentCloudflare.Infrastructure
{
    public class ResponseHasErrorsException : CloudflareException
    {
        private readonly List<Error> _errors = new List<Error>();
        public IReadOnlyList<Error> Errors => _errors.AsReadOnly();

        public ResponseHasErrorsException()
        {
        }

        public ResponseHasErrorsException(string message) : base(message)
        {
        }

        public ResponseHasErrorsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ResponseHasErrorsException(string message, List<Error> errors) : base(message)
        {
            _errors = errors ?? throw new ArgumentNullException(nameof(errors));
        }

        protected ResponseHasErrorsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
