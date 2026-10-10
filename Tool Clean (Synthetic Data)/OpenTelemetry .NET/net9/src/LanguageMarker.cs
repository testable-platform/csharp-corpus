// LANGUAGE MARKER -- net9.0, C# 13.0.
// Legal at C# 13.0; does not compile at C# 12.0. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.


namespace LanguageMarkers.OpentelemetryNet
{

    /// <summary>LANGUAGE MARKER -- C# 13. The `\e` escape sequence and a PARTIAL
    /// PROPERTY. C# 12 has neither: `\e` is not a recognised escape, and partial
    /// was not permitted on a property.</summary>
    internal partial class OpentelemetryNetLanguageMarker
    {
        internal const char ResetOpentelemetryNet = '\e';

        internal partial int RegionOpentelemetryNet { get; set; }
    }

    internal partial class OpentelemetryNetLanguageMarker
    {
        private int _regionOpentelemetryNet = 1;

        internal partial int RegionOpentelemetryNet
        {
            get => _regionOpentelemetryNet;
            set => _regionOpentelemetryNet = value < 0 ? 1 : value;
        }
    }
}
