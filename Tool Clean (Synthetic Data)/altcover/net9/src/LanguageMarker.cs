// LANGUAGE MARKER -- net9.0, C# 13.0.
// Legal at C# 13.0; does not compile at C# 12.0. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Altcover
{

    /// <summary>LANGUAGE MARKER -- C# 13. The `\e` escape sequence and a PARTIAL
    /// PROPERTY. C# 12 has neither: `\e` is not a recognised escape, and partial
    /// was not permitted on a property.</summary>
    internal partial class AltcoverLanguageMarker
    {
        internal const char ResetAltcover = '\e';

        internal partial int RegionAltcover { get; set; }
    }

    internal partial class AltcoverLanguageMarker
    {
        private int _regionAltcover = 1;

        internal partial int RegionAltcover
        {
            get => _regionAltcover;
            set => _regionAltcover = value < 0 ? 1 : value;
        }
    }
}
