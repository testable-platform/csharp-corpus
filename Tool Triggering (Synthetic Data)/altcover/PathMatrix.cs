// Tool Triggering (Synthetic Data) -- AltCover
//
// PLANTED: three independent decisions giving 8 paths against 6 branches
// EXPECTED: a path count that differs from the branch count
//
// Family net471, C# 7.2. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 7.2 (it does not compile under C# 7.1).

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

    /// <summary>LANGUAGE MARKER -- C# 7.2. An `in` parameter, a `private protected`
    /// member and a leading digit separator after the hex prefix. C# 7.1 has
    /// none of the three.</summary>
    internal class AltcoverLanguageMarker
    {
        private protected const int Mask = 0x_FF;

        internal static long Combine(in long cents, in long freight)
        {
            return (cents + freight) & Mask;
        }
    }
}
