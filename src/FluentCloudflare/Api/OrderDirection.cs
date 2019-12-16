using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Api
{
    public enum OrderDirection
    {
        Asc, Desc
    }

    internal static class OrderDirectionExtensions
    {
        public static string ToApiValue(this OrderDirection value)
            => Enum.GetName(typeof(OrderDirection), value).ToLowerInvariant();
    }
}
