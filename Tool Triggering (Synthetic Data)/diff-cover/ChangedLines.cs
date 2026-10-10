// Tool Triggering (Synthetic Data) -- diff-cover
//
// PLANTED: a sample Cobertura report plus the file it attributes
// EXPECTED: partial coverage on ChangedLines.cs, not 0% and not 100%
//
// Family net10.0, C# 14.0. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 14.0 (it does not compile under C# 13.0).

using System;
using System.Collections.Generic;

namespace OrderKit.ToolData.DiffCover
{

    /// <summary>The lines diff-cover should attribute. Lines 1-2 of Reprice are
    /// recorded as covered in this folder's coverage.cobertura.xml and the
    /// remaining branch is recorded as uncovered, so a correct run reports partial
    /// coverage on this file rather than 100% or 0%.</summary>
    public static class ChangedLines
    {
        public static long Reprice(long cents, bool apply)
        {
            long repriced = cents;
            if (apply) repriced = cents - (cents / 10);
            if (repriced < 0) repriced = 0;
            return repriced;
        }
    }

    /// <summary>LANGUAGE MARKER -- C# 14. The `field` contextual keyword inside an
    /// accessor, and `nameof` over an UNBOUND generic type. C# 13 has neither.
    ///
    /// NOTE: this family's src/ also uses `extension` blocks and `params`
    /// collections. They are correct C# 14 and deliberately absent here, because
    /// the tree-sitter grammar this generator self-checks with predates them and
    /// would report its own false failure. The authoritative gate is csc.</summary>
    internal class DiffCoverLanguageMarker
    {
        internal int Score
        {
            get => field;
            set => field = value < 0 ? 0 : value;
        }

        internal static string ListName() => nameof(List<>);
    }
}
