using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Abstractions.Builders.Accounts
{
    public interface IAccountsSyntax : IFluentSyntax
    {
        IResponseApiMethod<Account> Get(string identifier);
        IAccountsListSyntax List();
    }
}
