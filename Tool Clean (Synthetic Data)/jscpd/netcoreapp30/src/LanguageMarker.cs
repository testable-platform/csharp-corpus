// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Jscpd
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class JscpdLanguageMarker
    {
        internal static string BandJscpd(int scoreJscpd) => scoreJscpd switch
        {
            0 => "noneJscpd",
            1 => "lowJscpd",
            _ => "highJscpd",
        };

        internal static string NormaliseJscpd(string regionJscpd)
        {
            regionJscpd ??= "domestic";
            return regionJscpd.Length > 2 ? regionJscpd[1..] : regionJscpd;
        }
    }
}
