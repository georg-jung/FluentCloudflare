using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Abstractions.Infrastructure
{
    internal interface IRequestBuilderFactory
    {
        IRequestBuilder CreateRequestBuilder();
    }
}
