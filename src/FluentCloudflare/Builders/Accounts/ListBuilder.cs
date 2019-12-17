using FluentCloudflare.Abstractions.Builders.Accounts;
using FluentCloudflare.Abstractions.Infrastructure;
using FluentCloudflare.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Builders.Accounts
{
    internal class ListBuilder : ListBuilderBase<IAccountsListSyntax, Account>, IAccountsListSyntax
    {
        public ListBuilder(IRequestBuilderFactory context) : base(context, 50)
        {
        }

        protected override IAccountsListSyntax GetThis() => this;
    }
}
