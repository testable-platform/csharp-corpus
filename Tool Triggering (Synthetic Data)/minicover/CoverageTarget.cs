// Tool Triggering (Synthetic Data) -- MiniCover
//
// PLANTED: an instrumentable accumulate/classify pair
// EXPECTED: instrumented statement hits
//
// Family netcoreapp3.0, C# 8.0. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 8.0 (it does not compile under C# 7.3).

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

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class MinicoverLanguageMarker
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
