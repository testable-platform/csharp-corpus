// LANGUAGE MARKER -- net9.0, C# 13.0.
// Legal at C# 13.0; does not compile at C# 12.0. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Minicover
{

    /// <summary>LANGUAGE MARKER -- C# 13. The `\e` escape sequence and a PARTIAL
    /// PROPERTY. C# 12 has neither: `\e` is not a recognised escape, and partial
    /// was not permitted on a property.</summary>
    internal partial class MinicoverLanguageMarker
    {
        internal const char ResetMinicover = '\e';

        internal partial int RegionMinicover { get; set; }
    }

    internal partial class MinicoverLanguageMarker
    {
        private int _regionMinicover = 1;

        internal partial int RegionMinicover
        {
            get => _regionMinicover;
            set => _regionMinicover = value < 0 ? 1 : value;
        }
    }
}
