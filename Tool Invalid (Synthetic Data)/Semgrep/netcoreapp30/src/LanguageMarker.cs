// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Semgrep
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class SemgrepLanguageMarker
    {
        internal static string BandSemgrep(int scoreSemgrep) => scoreSemgrep switch
        {
            0 => "noneSemgrep",
            1 => "lowSemgrep",
            _ => "highSemgrep",
        };

        internal static string NormaliseSemgrep(string regionSemgrep)
        {
            regionSemgrep ??= "domestic";
            return regionSemgrep.Length > 2 ? regionSemgrep[1..] : regionSemgrep;
        }
    }
}
