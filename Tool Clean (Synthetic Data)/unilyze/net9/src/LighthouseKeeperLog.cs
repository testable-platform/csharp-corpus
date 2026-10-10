using System;
using System.Collections.Generic;

namespace Coastal.Lighthouse
{
    /// <summary>
    /// Synthetic, clean-by-design domain for unilyze: a lighthouse keeper's
    /// shift log. Every method is short, shallow and single-purpose -- well
    /// under unilyze's own default smell thresholds.
    /// </summary>
    public sealed class LighthouseKeeperLogV9
    {
        private readonly List<string> _entriesV9 = new List<string>();

        public int EntryCountV9 => _entriesV9.Count;

        public void RecordV9(string keeperNameV9, string observationV9)
        {
            if (string.IsNullOrWhiteSpace(keeperNameV9))
            {
                throw new ArgumentException("keeperName is required", nameof(keeperNameV9));
            }

            _entriesV9.Add(FormatEntryV9(keeperNameV9, observationV9));
        }

        private static string FormatEntryV9(string keeperNameV9, string observationV9)
        {
            var timestampV9 = DateTime.UtcNow.ToString("u");
            return $"[{timestampV9}] {keeperNameV9}: {observationV9}";
        }

        public bool HasEntriesV9()
        {
            return _entriesV9.Count > 0;
        }

        public string LatestEntryV9()
        {
            return HasEntriesV9() ? _entriesV9[_entriesV9.Count - 1] : string.Empty;
        }

        public IReadOnlyList<string> AllEntriesV9()
        {
            return _entriesV9.AsReadOnly();
        }
    }
}
