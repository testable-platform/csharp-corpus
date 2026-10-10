// LANGUAGE MARKER -- net46, C# 6.
// Legal at C# 6; does not compile at C# 5. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Roslyn
{

    /// <summary>LANGUAGE MARKER -- C# 6. String interpolation, `nameof`, an
    /// expression-bodied member and an auto-property initializer. None of the four
    /// exists in C# 5.</summary>
    internal static class RoslynLanguageMarker
    {
        internal static int TagRoslyn { get; } = 7;

        internal static string DescribeRoslyn(long centsRoslyn) => $"{nameof(RoslynLanguageMarker)}:{centsRoslyn}:{TagRoslyn}";
    }
}
