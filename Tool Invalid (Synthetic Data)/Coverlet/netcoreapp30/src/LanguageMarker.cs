// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Coverlet
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class CoverletLanguageMarker
    {
        internal static string BandCoverlet(int scoreCoverlet) => scoreCoverlet switch
        {
            0 => "noneCoverlet",
            1 => "lowCoverlet",
            _ => "highCoverlet",
        };

        internal static string NormaliseCoverlet(string regionCoverlet)
        {
            regionCoverlet ??= "domestic";
            return regionCoverlet.Length > 2 ? regionCoverlet[1..] : regionCoverlet;
        }
    }
}
