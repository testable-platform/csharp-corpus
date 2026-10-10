// LANGUAGE MARKER -- net9.0, C# 13.0.
// Legal at C# 13.0; does not compile at C# 12.0. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.Dolos
{

    /// <summary>LANGUAGE MARKER -- C# 13. The `\e` escape sequence and a PARTIAL
    /// PROPERTY. C# 12 has neither: `\e` is not a recognised escape, and partial
    /// was not permitted on a property.</summary>
    internal partial class DolosLanguageMarker
    {
        internal const char ResetDolos = '\e';

        internal partial int RegionDolos { get; set; }
    }

    internal partial class DolosLanguageMarker
    {
        private int _regionDolos = 1;

        internal partial int RegionDolos
        {
            get => _regionDolos;
            set => _regionDolos = value < 0 ? 1 : value;
        }
    }
}
