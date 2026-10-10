// Tool Triggering (Synthetic Data) -- MiniCover
//
// PLANTED: an instrumentable accumulate/classify pair
// EXPECTED: instrumented statement hits
//
// Family net47, C# 7.1. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 7.1 (it does not compile under C# 7.0).

using System;

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

    /// <summary>LANGUAGE MARKER -- C# 7.1. The `default` literal expression, with
    /// no type named. C# 7.0 requires `default(long)`.</summary>
    internal static class MinicoverLanguageMarker
    {
        internal static long Fallback(bool present)
        {
            long cents = default;
            return present ? 1 : cents;
        }
    }
}
