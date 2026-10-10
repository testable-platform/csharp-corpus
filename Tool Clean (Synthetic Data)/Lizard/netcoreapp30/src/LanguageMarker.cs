// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Lizard
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class LizardLanguageMarker
    {
        internal static string BandLizard(int scoreLizard) => scoreLizard switch
        {
            0 => "noneLizard",
            1 => "lowLizard",
            _ => "highLizard",
        };

        internal static string NormaliseLizard(string regionLizard)
        {
            regionLizard ??= "domestic";
            return regionLizard.Length > 2 ? regionLizard[1..] : regionLizard;
        }
    }
}
