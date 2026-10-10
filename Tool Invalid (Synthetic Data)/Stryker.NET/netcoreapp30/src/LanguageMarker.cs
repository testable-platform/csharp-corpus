// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.StrykerNet
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class StrykerNetLanguageMarker
    {
        internal static string BandStrykerNet(int scoreStrykerNet) => scoreStrykerNet switch
        {
            0 => "noneStrykerNet",
            1 => "lowStrykerNet",
            _ => "highStrykerNet",
        };

        internal static string NormaliseStrykerNet(string regionStrykerNet)
        {
            regionStrykerNet ??= "domestic";
            return regionStrykerNet.Length > 2 ? regionStrykerNet[1..] : regionStrykerNet;
        }
    }
}
