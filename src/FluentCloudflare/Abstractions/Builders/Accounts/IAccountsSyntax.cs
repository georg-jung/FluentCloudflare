using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Abstractions.Builders.Accounts
{
    public interface IAccountsSyntax : IFluentSyntax
    {
        IAccountsListSyntax List();
    }
}
