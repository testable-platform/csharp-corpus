// Tool Triggering (Synthetic Data) -- Roslyn analyzers (cognitive complexity)
//
// PLANTED: a method written past SonarAnalyzer S3776's default threshold of 15
// EXPECTED: at least one S3776 diagnostic on CognitiveComplexityS3776.Classify
//
// Family net10.0, C# 14.0. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 14.0 (it does not compile under C# 13.0).

using System;
using System.Collections.Generic;

namespace OrderKit.ToolData.RoslynMetrics
{

    /// <summary>SonarAnalyzer.CSharp rule S3776 raises when a method's cognitive
    /// complexity exceeds its threshold (15 by default). This method is written to
    /// clear that threshold on purpose, so S3776 has something to report and a
    /// clean result from this folder can be told apart from a scan that never
    /// ran.</summary>
    public static class CognitiveComplexityS3776
    {
        public static string Classify(int amount, string channel, string tier,
                                      bool refunded, bool disputed, bool flagged)
        {
            if (amount < 0)
            {
                if (refunded)
                {
                    if (disputed) return "refund-disputed";
                    return "refund";
                }
                return "negative";
            }

            if (channel == "web")
            {
                if (tier == "gold")
                {
                    if (flagged && amount > 1000) return "web-gold-review";
                    if (amount > 1000) return "web-gold-large";
                    return "web-gold";
                }
                if (tier == "silver")
                {
                    if (disputed || flagged) return "web-silver-review";
                    return "web-silver";
                }
                return "web";
            }

            if (channel == "mobile")
            {
                if (flagged)
                {
                    if (amount > 500 && !refunded) return "mobile-review";
                    return "mobile-flagged";
                }
                return "mobile";
            }

            if (channel == "partner" && amount > 0)
            {
                if (tier == "gold" || tier == "platinum") return "partner-priority";
                return "partner";
            }

            return "other";
        }
    }

    /// <summary>LANGUAGE MARKER -- C# 14. The `field` contextual keyword inside an
    /// accessor, and `nameof` over an UNBOUND generic type. C# 13 has neither.
    ///
    /// NOTE: this family's src/ also uses `extension` blocks and `params`
    /// collections. They are correct C# 14 and deliberately absent here, because
    /// the tree-sitter grammar this generator self-checks with predates them and
    /// would report its own false failure. The authoritative gate is csc.</summary>
    internal class RoslynMetricsLanguageMarker
    {
        internal int Score
        {
            get => field;
            set => field = value < 0 ? 0 : value;
        }

        internal static string ListName() => nameof(List<>);
    }
}
