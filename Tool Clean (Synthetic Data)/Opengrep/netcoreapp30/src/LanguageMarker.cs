// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Opengrep
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class OpengrepLanguageMarker
    {
        internal static string BandOpengrep(int scoreOpengrep) => scoreOpengrep switch
        {
            0 => "noneOpengrep",
            1 => "lowOpengrep",
            _ => "highOpengrep",
        };

        internal static string NormaliseOpengrep(string regionOpengrep)
        {
            regionOpengrep ??= "domestic";
            return regionOpengrep.Length > 2 ? regionOpengrep[1..] : regionOpengrep;
        }
    }
}
