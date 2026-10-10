// LANGUAGE MARKER -- net10.0, C# 14.0.
// Legal at C# 14.0; does not compile at C# 13.0. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.

using System.Collections.Generic;

namespace LanguageMarkers.NugetAudit
{

    /// <summary>LANGUAGE MARKER -- C# 14. The `field` contextual keyword inside an
    /// accessor, and `nameof` over an UNBOUND generic type. C# 13 has neither.
    ///
    /// NOTE: this family's src/ also uses `extension` blocks and `params`
    /// collections. They are correct C# 14 and deliberately absent here, because
    /// the tree-sitter grammar this generator self-checks with predates them and
    /// would report its own false failure. The authoritative gate is csc.</summary>
    internal class NugetAuditLanguageMarker
    {
        internal int ScoreNugetAudit
        {
            get => field;
            set => field = value < 0 ? 0 : value;
        }

        internal static string ListNameNugetAudit() => nameof(List<>);
    }
}
