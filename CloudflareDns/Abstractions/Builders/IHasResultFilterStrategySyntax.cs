using Cloudflare.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudflare.Abstractions.Builders
{
    public interface IHasResultFilterStrategySyntax<TBuilder>
    {
        /// <summary>
        /// Whether to match all search requirements or at least one (any)
        /// </summary>
        TBuilder Match(MatchType type);
    }
}
