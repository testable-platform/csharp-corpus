// Tool Triggering (Synthetic Data) -- AltCover
//
// PLANTED: three independent decisions giving 8 paths against 6 branches
// EXPECTED: a path count that differs from the branch count
//
// Family netcoreapp3.0, C# 8.0. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 8.0 (it does not compile under C# 7.3).

using System;

namespace OrderKit.ToolData.Altcover
{

    /// <summary>Path-coverage target. Three independent two-way decisions give
    /// eight distinct paths through one method, so path coverage and branch
    /// coverage cannot report the same number -- 6 branches against 8 paths. A
    /// tool that claims path coverage but counts branches is visible here.</summary>
    public static class PathMatrix
    {
        public static int Route(bool a, bool b, bool c)
        {
            int path = 0;
            if (a) path = path + 1;
            if (b) path = path + 2;
            if (c) path = path + 4;
            return path;
        }

        public static string Describe(bool a, bool b, bool c)
        {
            if (a)
            {
                if (b) return c ? "abc" : "ab";
                return c ? "ac" : "a";
            }
            if (b) return c ? "bc" : "b";
            return c ? "c" : "none";
        }
    }

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class AltcoverLanguageMarker
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
