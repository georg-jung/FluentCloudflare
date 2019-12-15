using Cloudflare.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Api
{
    public enum ZoneStatus
    {
        Active, Pending, Initializing, Moved, Deleted, Deactivated
    }

    internal static class ZoneStatusExtensions
    {
        public static string ToApiValue(this ZoneStatus value)
            => value.ToName();
    }
}
