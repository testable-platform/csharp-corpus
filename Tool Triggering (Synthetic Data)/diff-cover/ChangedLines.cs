// Tool Triggering (Synthetic Data) -- diff-cover
//
// PLANTED: a sample Cobertura report plus the file it attributes
// EXPECTED: partial coverage on ChangedLines.cs, not 0% and not 100%
//
// Family netcoreapp3.0, C# 8.0. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 8.0 (it does not compile under C# 7.3).

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

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class DiffCoverLanguageMarker
    {
        internal static string Band(int score) => score switch
        {
            0 => "none",
            1 => "low",
            _ => "high",
        };

        internal static string Normalise(string region)
        {
            region ??= "domestic";
            return region.Length > 2 ? region[1..] : region;
        }
    }
}
