// Tool Triggering (Synthetic Data) -- Stryker.NET
//
// PLANTED: arithmetic, relational and logical operators with non-equivalent boundaries
// EXPECTED: a mutation score with surviving and killed mutants that are not all equivalent
//
// Family net10.0, C# 14.0. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 14.0 (it does not compile under C# 13.0).

using System;
using System.Collections.Generic;

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

    /// <summary>LANGUAGE MARKER -- C# 14. The `field` contextual keyword inside an
    /// accessor, and `nameof` over an UNBOUND generic type. C# 13 has neither.
    ///
    /// NOTE: this family's src/ also uses `extension` blocks and `params`
    /// collections. They are correct C# 14 and deliberately absent here, because
    /// the tree-sitter grammar this generator self-checks with predates them and
    /// would report its own false failure. The authoritative gate is csc.</summary>
    internal class StrykerLanguageMarker
    {
        internal int Score
        {
            get => field;
            set => field = value < 0 ? 0 : value;
        }

        internal static string ListName() => nameof(List<>);
    }
}
