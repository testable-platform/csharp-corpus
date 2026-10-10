// Tool Triggering (Synthetic Data) -- unilyze
//
// PLANTED: a four-level nested method, charged for depth as well as branches
// EXPECTED: a per-member cyclomaticComplexity and cognitiveComplexity peak on CognitiveHotspot.Score
//
// Family netcoreapp3.0, C# 8.0. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 8.0 (it does not compile under C# 7.3).

using System;

namespace OrderKit.ToolData.Unilyze
{

    /// <summary>unilyze reports per-member cyclomaticComplexity AND
    /// cognitiveComplexity. Cognitive complexity charges for NESTING, not just for
    /// branch count, so this fixture nests deliberately: the inner condition sits
    /// four levels deep and each level adds its depth to the score.</summary>
    public static class CognitiveHotspot
    {
        public static int Score(int[] signals, string[] flags, bool strict)
        {
            int score = 0;
            if (signals != null)
            {
                for (int i = 0; i < signals.Length; i++)
                {
                    if (signals[i] > 0)
                    {
                        if (signals[i] > 10 && signals[i] < 100)
                        {
                            if (strict || signals[i] % 2 == 0)
                            {
                                score = score + signals[i];
                            }
                            else
                            {
                                score = score - 1;
                            }
                        }
                        else if (signals[i] >= 100)
                        {
                            foreach (string flag in flags)
                            {
                                if (flag != null && flag.Length > 2)
                                {
                                    if (flag[0] == 'x' && !strict)
                                    {
                                        score = score + 2;
                                    }
                                    else if (flag[0] == 'y')
                                    {
                                        score = score + 3;
                                    }
                                }
                            }
                        }
                    }
                    else if (signals[i] < 0)
                    {
                        score = score - signals[i];
                    }
                }
            }
            return score;
        }
    }

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class UnilyzeLanguageMarker
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
