// Tool Triggering (Synthetic Data) -- diff-cover
//
// PLANTED: a sample Cobertura report plus the file it attributes
// EXPECTED: partial coverage on ChangedLines.cs, not 0% and not 100%
//
// Family net462, C# 7. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 7 (it does not compile under C# 6).

using System;

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

    /// <summary>LANGUAGE MARKER -- C# 7. An out-variable declaration, a tuple
    /// return, a local function and a digit separator. C# 6 has none of them.</summary>
    internal static class DiffCoverLanguageMarker
    {
        internal static (long cents, bool parsed) Parse(string raw)
        {
            long Scale(long v) => v * 1_000;
            if (long.TryParse(raw, out var parsed))
            {
                return (Scale(parsed), true);
            }
            return (0, false);
        }
    }
}
