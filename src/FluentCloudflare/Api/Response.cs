using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FluentCloudflare.Api
{
    public class Response<TResult>
    {
        public TResult Result { get; set; }
        public bool Success { get; set; }
        // Errors
        // Messages
        public ResultInfo ResultInfo { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public void EnsureSuccess()
        {
            if (!Success)
                throw new CloudflareException("The request was not successfull (success = false).");
            if (StatusCode != HttpStatusCode.OK)
                throw new CloudflareException($"The status code of the response was {StatusCode}.");

        }

        public TResult Unpack()
        {
            EnsureSuccess();
            if (Result == null)
                throw new CloudflareException("The response contained no result.");
            return Result;
        }
    }
}
