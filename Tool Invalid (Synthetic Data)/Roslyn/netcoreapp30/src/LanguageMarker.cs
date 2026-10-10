// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Roslyn
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class RoslynLanguageMarker
    {
        internal static string BandRoslyn(int scoreRoslyn) => scoreRoslyn switch
        {
            0 => "noneRoslyn",
            1 => "lowRoslyn",
            _ => "highRoslyn",
        };

        internal static string NormaliseRoslyn(string regionRoslyn)
        {
            regionRoslyn ??= "domestic";
            return regionRoslyn.Length > 2 ? regionRoslyn[1..] : regionRoslyn;
        }
    }
}
