using FluentCloudflare.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Abstractions.Infrastructure
{
    public interface IResponseApiMethod<TEntity> : IApiMethod<Response<TEntity>>
    {
    }
}
