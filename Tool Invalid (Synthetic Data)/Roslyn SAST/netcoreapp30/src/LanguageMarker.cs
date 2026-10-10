// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.RoslynSast
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class RoslynSastLanguageMarker
    {
        internal static string BandRoslynSast(int scoreRoslynSast) => scoreRoslynSast switch
        {
            0 => "noneRoslynSast",
            1 => "lowRoslynSast",
            _ => "highRoslynSast",
        };

        internal static string NormaliseRoslynSast(string regionRoslynSast)
        {
            regionRoslynSast ??= "domestic";
            return regionRoslynSast.Length > 2 ? regionRoslynSast[1..] : regionRoslynSast;
        }
    }
}
