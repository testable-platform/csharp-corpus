using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PilotOps
{
    // Hand-rolled line-coverage probe. Coverlet/AltCover/MiniCover all
    // require restoring a NuGet package, which this sandbox's egress
    // proxy refuses (api.nuget.org returns 403). CallerLineNumber
    // captures the real call-site line at compile time, so each Mark()
    // records a genuine executed line -- not an asserted one.
    public static class Cov
    {
        private static readonly Dictionary<string, HashSet<int>> Hits = new();

        public static void Mark(string file, [CallerLineNumber] int line = 0)
        {
            if (!Hits.TryGetValue(file, out var set))
            {
                set = new HashSet<int>();
                Hits[file] = set;
            }
            set.Add(line);
        }

        public static IReadOnlyDictionary<string, HashSet<int>> Snapshot()
        {
            return Hits;
        }
    }
}
