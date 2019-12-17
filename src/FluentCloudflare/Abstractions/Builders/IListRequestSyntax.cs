using FluentCloudflare.Abstractions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Abstractions.Builders
{
    public interface IListRequestSyntax<TBuilder, TEntity> : 
        IPaginatedSyntax<TBuilder>,
        IOrderedSyntax<TBuilder>,
        IHasResultFilterStrategySyntax<TBuilder>,
        IResponseApiMethod<TEntity>
    {
    }
}
