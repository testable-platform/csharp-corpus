// LANGUAGE MARKER -- net9.0, C# 13.0.
// Legal at C# 13.0; does not compile at C# 12.0. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.RoslynSast
{

    /// <summary>LANGUAGE MARKER -- C# 13. The `\e` escape sequence and a PARTIAL
    /// PROPERTY. C# 12 has neither: `\e` is not a recognised escape, and partial
    /// was not permitted on a property.</summary>
    internal partial class RoslynSastLanguageMarker
    {
        internal const char ResetRoslynSast = '\e';

        internal partial int RegionRoslynSast { get; set; }
    }

    internal partial class RoslynSastLanguageMarker
    {
        private int _regionRoslynSast = 1;

        internal partial int RegionRoslynSast
        {
            get => _regionRoslynSast;
            set => _regionRoslynSast = value < 0 ? 1 : value;
        }
    }
}
