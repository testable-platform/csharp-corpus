// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Trivy
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class TrivyLanguageMarker
    {
        internal static string BandTrivy(int scoreTrivy) => scoreTrivy switch
        {
            0 => "noneTrivy",
            1 => "lowTrivy",
            _ => "highTrivy",
        };

        internal static string NormaliseTrivy(string regionTrivy)
        {
            regionTrivy ??= "domestic";
            return regionTrivy.Length > 2 ? regionTrivy[1..] : regionTrivy;
        }
    }
}
