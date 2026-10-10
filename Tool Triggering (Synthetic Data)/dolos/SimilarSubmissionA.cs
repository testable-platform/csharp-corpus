// Tool Triggering (Synthetic Data) -- Dolos
//
// PLANTED: a similarity pair with renamed identifiers and reordered statements, not a token copy
// EXPECTED: a reported similarity between SimilarSubmissionA and SimilarSubmissionB
//
// Family net47, C# 7.1. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 7.1 (it does not compile under C# 7.0).

using System;

namespace OrderKit.ToolData.Dolos
{

    /// <summary>Half of the planted similarity pair. Unlike the jscpd pair this is
    /// NOT a token-for-token copy: identifiers are renamed and independent
    /// statements are reordered. A clone detector working on exact token runs can
    /// miss it; Dolos compares structure, so it should not.</summary>
    public static class SimilarSubmissionA
    {
        public static long Settle(long[] lines, int tier)
        {
            long total = 0;
            int count = 0;
            for (int index = 0; index < lines.Length; index++)
            {
                long current = lines[index];
                if (current <= 0) continue;
                count = count + 1;
                if (tier > 2) current = current / 2;
                if (current > 100) current = current - 10;
                total = total + current;
            }
            if (count == 0) return 0;
            return total / count;
        }
    }

    /// <summary>LANGUAGE MARKER -- C# 7.1. The `default` literal expression, with
    /// no type named. C# 7.0 requires `default(long)`.</summary>
    internal static class DolosLanguageMarker
    {
        internal static long Fallback(bool present)
        {
            long cents = default;
            return present ? 1 : cents;
        }
    }
}
