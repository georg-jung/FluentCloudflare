using Cloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Abstractions.Builders
{
    public interface IListRequestSyntax<TBuilder, TEntity> : 
        IPaginatedSyntax<TBuilder>,
        IHasResultFilterStrategySyntax<TBuilder>,
        IApiMethod<TEntity>
    {
    }
}
