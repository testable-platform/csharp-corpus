// Tool Triggering (Synthetic Data) -- MiniCover
//
// PLANTED: an instrumentable accumulate/classify pair
// EXPECTED: instrumented statement hits
//
// Family net10.0, C# 14.0. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 14.0 (it does not compile under C# 13.0).

using System;
using System.Collections.Generic;

namespace OrderKit.ToolData.Minicover
{

    /// <summary>Instrumentation target for MiniCover. MiniCover 3.10.0 declares
    /// net8.0/net9.0/net10.0 only -- verified from its own MiniCover.csproj -- so on
    /// ten of the thirteen families this fixture is present and the tool is not.
    /// That is the measurement: the data exists, and the tool's absence is
    /// attributable to the tool rather than to a missing fixture.</summary>
    public static class CoverageTarget
    {
        public static long Accumulate(long[] amounts, int tier)
        {
            long total = 0;
            for (int i = 0; i < amounts.Length; i++)
            {
                if (amounts[i] <= 0) continue;
                long amount = amounts[i];
                if (tier > 1) amount = amount - (amount / 20);
                total = total + amount;
            }
            return total;
        }

        public static int Tier(long total)
        {
            if (total > 100000) return 3;
            if (total > 10000) return 2;
            if (total > 0) return 1;
            return 0;
        }
    }

    /// <summary>LANGUAGE MARKER -- C# 14. The `field` contextual keyword inside an
    /// accessor, and `nameof` over an UNBOUND generic type. C# 13 has neither.
    ///
    /// NOTE: this family's src/ also uses `extension` blocks and `params`
    /// collections. They are correct C# 14 and deliberately absent here, because
    /// the tree-sitter grammar this generator self-checks with predates them and
    /// would report its own false failure. The authoritative gate is csc.</summary>
    internal class MinicoverLanguageMarker
    {
        internal int Score
        {
            get => field;
            set => field = value < 0 ? 0 : value;
        }

        internal static string ListName() => nameof(List<>);
    }
}
