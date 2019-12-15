using Cloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Api
{
    public enum ZoneOrderKey
    {
        Name, Status, AccountId, AccountName
    }

    internal static class ZoneOrderKeyExtensions
    {
        private static readonly Dictionary<string, string> Replacements = new Dictionary<string, string>() { { "accountid", "account.id" }, { "accountid", "account.name" } };

        public static string ToApiValue(this ZoneOrderKey value)
            => value.ToName(Replacements);
    }
}
