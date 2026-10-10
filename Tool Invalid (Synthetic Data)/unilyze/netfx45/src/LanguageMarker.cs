// LANGUAGE MARKER -- net45, C# 5.
// Legal at C# 5; does not compile at C# 4. This file pins the folder
// to the version it is named for. Nothing else in the folder depends on it.

using System.Threading.Tasks;

namespace LanguageMarkers.Unilyze
{

    /// <summary>LANGUAGE MARKER -- C# 5. An async method with `await`. C# 4 has no
    /// async modifier at all, so this file cannot be parsed as C# 4.</summary>
    internal static class UnilyzeLanguageMarker
    {
        internal static async Task<long> SettleAsyncUnilyze(long centsUnilyze)
        {
            await Task.Delay(1);
            return centsUnilyze;
        }
    }
}
