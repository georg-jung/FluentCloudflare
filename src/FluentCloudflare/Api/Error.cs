using System;
using System.Collections.Generic;
using System.Text;

namespace FluentCloudflare.Api
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Bezeichner dürfen nicht mit Schlüsselwörtern übereinstimmen", Justification = "This is called error by the API. Consumers possibly don't instantiate this class and in CSharp and FSharp this isn't a keyword. Conciseness over strange VB use cases.")]
    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
