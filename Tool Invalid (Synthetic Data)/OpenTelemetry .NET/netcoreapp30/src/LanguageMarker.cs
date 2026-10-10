// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.OpentelemetryNet
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class OpentelemetryNetLanguageMarker
    {
        internal static string BandOpentelemetryNet(int scoreOpentelemetryNet) => scoreOpentelemetryNet switch
        {
            0 => "noneOpentelemetryNet",
            1 => "lowOpentelemetryNet",
            _ => "highOpentelemetryNet",
        };

        internal static string NormaliseOpentelemetryNet(string regionOpentelemetryNet)
        {
            regionOpentelemetryNet ??= "domestic";
            return regionOpentelemetryNet.Length > 2 ? regionOpentelemetryNet[1..] : regionOpentelemetryNet;
        }
    }
}
