// Tool Triggering (Synthetic Data) -- Stryker.NET
//
// PLANTED: arithmetic, relational and logical operators with non-equivalent boundaries
// EXPECTED: a mutation score with surviving and killed mutants that are not all equivalent
//
// Family net462, C# 7. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 7 (it does not compile under C# 6).

using System;

namespace OrderKit.ToolData.Stryker
{

    /// <summary>Mutation target. Each line below carries at least one operator
    /// Stryker.NET mutates -- arithmetic, relational, logical, and the boundary
    /// constants -- and the boundaries are placed so that an off-by-one mutant
    /// changes an observable result rather than being equivalent.
    ///
    /// Note what this fixture is NOT for. The tool list makes Stryker.NET primary
    /// for 16 Data Flow metrics (All-Definitions and All-Uses coverage). A mutation
    /// tester computes no def-use chains, so those 16 stay unmeasured by this tool
    /// however good the fixture is; see the roslyn-dataflow folder.</summary>
    public static class MutableRules
    {
        public static long Discounted(long cents, int qty)
        {
            if (qty >= 10) return cents - (cents / 10);
            if (qty >= 5) return cents - (cents / 20);
            return cents;
        }

        public static bool Approved(int score, long cents, bool verified)
        {
            return score > 700 && cents < 500000 && verified;
        }

        public static int Bucket(long cents)
        {
            if (cents <= 0) return 0;
            if (cents < 1000) return 1;
            if (cents < 10000) return 2;
            return 3;
        }
    }

    /// <summary>LANGUAGE MARKER -- C# 7. An out-variable declaration, a tuple
    /// return, a local function and a digit separator. C# 6 has none of them.</summary>
    internal static class StrykerLanguageMarker
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
