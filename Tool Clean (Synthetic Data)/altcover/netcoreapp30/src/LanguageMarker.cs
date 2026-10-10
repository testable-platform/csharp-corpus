// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Altcover
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class AltcoverLanguageMarker
    {
        internal static string BandAltcover(int scoreAltcover) => scoreAltcover switch
        {
            0 => "noneAltcover",
            1 => "lowAltcover",
            _ => "highAltcover",
        };

        internal static string NormaliseAltcover(string regionAltcover)
        {
            regionAltcover ??= "domestic";
            return regionAltcover.Length > 2 ? regionAltcover[1..] : regionAltcover;
        }
    }
}
