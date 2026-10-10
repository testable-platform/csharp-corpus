// Tool Triggering (Synthetic Data) -- AltCover
//
// PLANTED: three independent decisions giving 8 paths against 6 branches
// EXPECTED: a path count that differs from the branch count
//
// Family net7.0, C# 11.0. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 11.0 (it does not compile under C# 10.0).

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

    /// <summary>LANGUAGE MARKER -- C# 11. A raw string literal, a list pattern and
    /// a `required` member. C# 10 has none of them.</summary>
    internal class AltcoverLanguageMarker
    {
        internal required string Currency { get; init; }

        internal const string Schema = """
            { "key": "<pricing-key>", "cents": 0 }
            """;

        internal static bool IsBookend(int[] steps)
        {
            return steps is [1, .., 9];
        }
    }
}
