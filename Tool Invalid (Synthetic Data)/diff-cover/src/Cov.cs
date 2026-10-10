using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ReclaimOps
{
    // Hand-rolled line-coverage probe, identical in mechanism to the sibling
    // CSharp-Tools-Clean diff-cover folder: Coverlet/AltCover/MiniCover all
    // need a NuGet restore this sandbox's egress proxy refuses, so this
    // records real executed lines via CallerLineNumber instead.
    public static class Cov
    {
        private static readonly Dictionary<string, HashSet<int>> Hits = new Dictionary<string, HashSet<int>>();

        public static void Mark(string file, [CallerLineNumber] int line = 0)
        {
            HashSet<int> set;
            if (!Hits.TryGetValue(file, out set))
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
