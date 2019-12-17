using FluentCloudflare.Abstractions.Builders.Accounts;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api.Entities;
using FluentCloudflare.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Builders.Accounts
{
    internal class AccountsBuilder : UrlExtender, IAccountsSyntax
    {
        internal AccountsBuilder(IRequestBuilderFactory context) : base(context, "accounts")
        {
        }

        public IResponseApiMethod<Account> Get(string identifier)
        {
            return new ResponseApiMethodBuilder<Account>(new UrlExtender(this, identifier));
        }

        public IAccountsListSyntax List()
        {
            return new ListBuilder(this);
        }
    }
}
