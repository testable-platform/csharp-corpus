// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Dolos
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class DolosLanguageMarker
    {
        internal static string BandDolos(int scoreDolos) => scoreDolos switch
        {
            0 => "noneDolos",
            1 => "lowDolos",
            _ => "highDolos",
        };

        internal static string NormaliseDolos(string regionDolos)
        {
            regionDolos ??= "domestic";
            return regionDolos.Length > 2 ? regionDolos[1..] : regionDolos;
        }
    }
}
