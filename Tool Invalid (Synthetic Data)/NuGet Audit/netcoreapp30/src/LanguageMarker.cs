// LANGUAGE MARKER -- netcoreapp3.0, C# 8.0.
// Legal at C# 8.0; does not compile at C# 7.3. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.NugetAudit
{

    /// <summary>LANGUAGE MARKER -- C# 8. A switch EXPRESSION, the null-coalescing
    /// assignment `??=` and a range index. C# 7.3 has none of them.</summary>
    internal static class NugetAuditLanguageMarker
    {
        internal static string BandNugetAudit(int scoreNugetAudit) => scoreNugetAudit switch
        {
            0 => "noneNugetAudit",
            1 => "lowNugetAudit",
            _ => "highNugetAudit",
        };

        internal static string NormaliseNugetAudit(string regionNugetAudit)
        {
            regionNugetAudit ??= "domestic";
            return regionNugetAudit.Length > 2 ? regionNugetAudit[1..] : regionNugetAudit;
        }
    }
}
