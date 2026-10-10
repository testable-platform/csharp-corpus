// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Unilyze
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class UnilyzeLanguageMarker
    {
        internal static string BandUnilyze(int scoreUnilyze) => scoreUnilyze switch
        {
            0 => "noneUnilyze",
            1 => "lowUnilyze",
            _ => "highUnilyze",
        };

        internal static string NormaliseUnilyze(string regionUnilyze)
        {
            regionUnilyze ??= "domestic";
            return regionUnilyze.Length > 2 ? regionUnilyze[1..] : regionUnilyze;
        }
    }
}
