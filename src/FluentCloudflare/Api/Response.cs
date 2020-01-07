using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace FluentCloudflare.Api
{
    public class Response<TResult>
    {
        public TResult Result { get; set; }
        public bool Success { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Sammlungseigenschaften müssen schreibgeschützt sein", Justification = "This represents poco-style entities returned by the rest API which are deserialized.")]
        public List<Error> Errors { get; set; }

        // Messages seems to be unused by the Cloudflare API, so it is not implemented here.
        // It does not seem to make sense to assume any details what a message could be, so
        // regarding backwards compatibility of future releases it seems preferable to leave
        // this unimplemented.
        // Messages
        
        public ResultInfo ResultInfo { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public void EnsureSuccess()
        {
            if (Errors?.FirstOrDefault() is Error err)
                throw new ResponseHasErrorsException($"The response contained at least one error. First error: Code = {err.Code}, Message = {err.Message}", Errors);
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
