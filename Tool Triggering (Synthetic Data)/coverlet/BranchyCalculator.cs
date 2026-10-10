// Tool Triggering (Synthetic Data) -- Coverlet
//
// PLANTED: a branch-dense target where statement and branch coverage genuinely differ
// EXPECTED: a statement-coverage and a branch-coverage number that are not equal
//
// Family net471, C# 7.2. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 7.2 (it does not compile under C# 7.1).

using System;

namespace OrderKit.ToolData.Coverlet
{

    /// <summary>Statement- and branch-coverage target. Every branch below is
    /// reachable, and no two branches are equivalent, so a statement-coverage
    /// number and a branch-coverage number genuinely differ on this fixture --
    /// which is what makes Coverlet's two headline metrics distinguishable
    /// instead of identical.</summary>
    public static class BranchyCalculator
    {
        public static long Net(long gross, int qty, bool taxable, string region)
        {
            long net = gross;
            if (qty <= 0) return 0;
            if (qty > 100) net = net - (net / 10);
            if (taxable) net = net + (net / 8);
            if (region == "eu") net = net + 120;
            else if (region == "apac") net = net + 220;
            if (net < 0) net = 0;
            return net;
        }

        public static bool Eligible(int score, bool verified)
        {
            if (score >= 700 && verified) return true;
            if (score >= 800) return true;
            return false;
        }
    }

    /// <summary>LANGUAGE MARKER -- C# 7.2. An `in` parameter, a `private protected`
    /// member and a leading digit separator after the hex prefix. C# 7.1 has
    /// none of the three.</summary>
    internal class CoverletLanguageMarker
    {
        private protected const int Mask = 0x_FF;

        internal static long Combine(in long cents, in long freight)
        {
            return (cents + freight) & Mask;
        }
    }
}
