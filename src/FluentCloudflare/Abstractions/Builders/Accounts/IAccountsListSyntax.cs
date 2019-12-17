using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;
using System.Collections.Generic;

namespace FluentCloudflare.Abstractions.Builders.Accounts
{
    public interface IAccountsListSyntax : IFluentSyntax, IPaginatedSyntax<IAccountsListSyntax>, IResponseApiMethod<List<Account>>
    {
    }
}