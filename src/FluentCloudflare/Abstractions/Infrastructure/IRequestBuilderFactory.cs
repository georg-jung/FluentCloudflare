using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Abstractions.Infrastructure
{
    internal interface IRequestBuilderFactory
    {
        IRequestBuilder CreateRequestBuilder();
    }
}
