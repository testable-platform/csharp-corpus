// Tool Invalid (Synthetic Data) -- dotnet list package --vulnerable
//
// PLANTED: the reference-graph guard: all five planted pins named from compiled code
// EXPECTED: five vulnerable packages, read from the branch's own root manifest
//
// Family net10.0, C# 14.0. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 14.0 (it does not compile under C# 13.0).

using System;
using System.Collections.Generic;

namespace OrderKit.ToolData.NugetAudit
{

    /// <summary>`dotnet list package --vulnerable` reads the RESTORED package graph
    /// of a real project; it cannot read a folder. So this folder deliberately
    /// carries no manifest of its own -- one here would be treated as a separate
    /// project by the platform -- and the audit's actual input stays the branch's
    /// own root manifest.
    ///
    /// What this file contributes is the reference-graph guard: every planted
    /// package is named from compiled code, so an SCA tool that walks references
    /// rather than only the manifest still finds all five. The TypeScript corpus
    /// shipped declared-but-unimported packages, measured zero, and exited 0.</summary>
    public static class AdvisorySurface
    {
        public static IEnumerable<string> VulnerablePins()
        {
            List<string> pins = new List<string>();
            pins.Add("Newtonsoft.Json/9.0.1");
            pins.Add("System.Net.Http/4.3.0");
            pins.Add("Microsoft.AspNet.Mvc/5.2.3");
            pins.Add("System.Text.RegularExpressions/4.3.0");
            pins.Add("BouncyCastle/1.8.1");
            return pins;
        }

        public static int DeclaredCount()
        {
            int n = 0;
            foreach (string pin in VulnerablePins()) n = n + 1;
            return n;
        }
    }

    /// <summary>LANGUAGE MARKER -- C# 14. The `field` contextual keyword inside an
    /// accessor, and `nameof` over an UNBOUND generic type. C# 13 has neither.
    ///
    /// NOTE: this family's src/ also uses `extension` blocks and `params`
    /// collections. They are correct C# 14 and deliberately absent here, because
    /// the tree-sitter grammar this generator self-checks with predates them and
    /// would report its own false failure. The authoritative gate is csc.</summary>
    internal class NugetAuditLanguageMarker
    {
        internal int Score
        {
            get => field;
            set => field = value < 0 ? 0 : value;
        }

        internal static string ListName() => nameof(List<>);
    }
}
