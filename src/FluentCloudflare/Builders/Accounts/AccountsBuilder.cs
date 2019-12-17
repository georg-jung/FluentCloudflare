using FluentCloudflare.Abstractions.Builders.Accounts;
using FluentCloudflare.Abstractions.Infrastructure;
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

        public IAccountsListSyntax List()
        {
            return new ListBuilder(this);
        }
    }
}
