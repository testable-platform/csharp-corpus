// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Minicover
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class MinicoverLanguageMarker
    {
        internal static string BandMinicover(int scoreMinicover) => scoreMinicover switch
        {
            0 => "noneMinicover",
            1 => "lowMinicover",
            _ => "highMinicover",
        };

        internal static string NormaliseMinicover(string regionMinicover)
        {
            regionMinicover ??= "domestic";
            return regionMinicover.Length > 2 ? regionMinicover[1..] : regionMinicover;
        }
    }
}
