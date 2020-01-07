// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Literale nicht als lokalisierte Parameter übergeben", Justification = "Localization is out of scope.", Scope = "namespaceanddescendants", Target = "FluentCloudflare")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Sammlungseigenschaften müssen schreibgeschützt sein", Justification = "These classes represent poco-style entities returned by the rest API which are deserialized.", Scope = "namespaceanddescendants", Target = "FluentCloudflare.Api.Entities")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1716:Bezeichner dürfen nicht mit Schlüsselwörtern übereinstimmen", Justification = "Naming is intentional to match rest api logic", Scope = "namespaceanddescendants", Target = "FluentCloudflare.Abstractions.Builders")]
