// Tool Triggering (Synthetic Data) -- AltCover
//
// PLANTED: three independent decisions giving 8 paths against 6 branches
// EXPECTED: a path count that differs from the branch count
//
// Family net45, C# 5. The core below is C# 5-compatible so it is identical on
// every family; the LanguageMarker class at the bottom is what pins this file
// to C# 5 (it does not compile under C# 4).

using System;
using System.Threading.Tasks;

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

    /// <summary>LANGUAGE MARKER -- C# 5. An async method with `await`. C# 4 has no
    /// async modifier at all, so this file cannot be parsed as C# 4.</summary>
    internal static class AltcoverLanguageMarker
    {
        internal static async Task<long> SettleAsync(long cents)
        {
            await Task.Delay(1);
            return cents;
        }
    }
}
