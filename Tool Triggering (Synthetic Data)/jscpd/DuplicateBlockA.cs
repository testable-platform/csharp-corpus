// Tool Triggering (Synthetic Data) -- jscpd
//
// PLANTED: a duplicate pair identical modulo one name, well past --min-tokens 50
// EXPECTED: duplicates >= 1, and sources > 0
//
// Family netcoreapp3.0, C# 8.0. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 8.0 (it does not compile under C# 7.3).

using System;

namespace OrderKit.ToolData.Jscpd
{

    /// <summary>Half of the planted duplicate pair. The two blocks are identical
    /// modulo the class name and one local, and run to well over jscpd's
    /// --min-tokens 50, so a correct run reports at least one clone. dataset.json
    /// asserts jscpd.duplicates >= 1.</summary>
    public static class DuplicateBlockA
    {
        public static long Settle(long[] lines, string region, int tier)
        {
            long runningTotal = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                long amount = lines[i];
                if (amount <= 0) continue;
                if (tier == 1) amount = amount - (amount / 20);
                else if (tier == 2) amount = amount - (amount / 10);
                else if (tier == 3) amount = amount - (amount / 5);
                if (region == "eu") amount = amount + 120;
                else if (region == "apac") amount = amount + 220;
                else amount = amount + 20;
                if (amount < 0) amount = 0;
                runningTotal = runningTotal + amount;
            }
            if (runningTotal > 1000000) runningTotal = 1000000;
            return runningTotal;
        }
    }

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class JscpdLanguageMarker
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
