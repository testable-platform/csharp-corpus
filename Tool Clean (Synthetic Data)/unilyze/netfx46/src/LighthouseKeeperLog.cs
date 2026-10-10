using System;
using System.Collections.Generic;

namespace Coastal.Lighthouse
{
    /// <summary>
    /// Synthetic, clean-by-design domain for unilyze: a lighthouse keeper's
    /// shift log. Every method is short, shallow and single-purpose -- well
    /// under unilyze's own default smell thresholds.
    /// </summary>
    public sealed class LighthouseKeeperLogV46
    {
        private readonly List<string> _entriesV46 = new List<string>();

        public int EntryCountV46 => _entriesV46.Count;

        public void RecordV46(string keeperNameV46, string observationV46)
        {
            if (string.IsNullOrWhiteSpace(keeperNameV46))
            {
                throw new ArgumentException("keeperName is required", nameof(keeperNameV46));
            }

            _entriesV46.Add(FormatEntryV46(keeperNameV46, observationV46));
        }

        private static string FormatEntryV46(string keeperNameV46, string observationV46)
        {
            var timestampV46 = DateTime.UtcNow.ToString("u");
            return $"[{timestampV46}] {keeperNameV46}: {observationV46}";
        }

        public bool HasEntriesV46()
        {
            return _entriesV46.Count > 0;
        }

        public string LatestEntryV46()
        {
            return HasEntriesV46() ? _entriesV46[_entriesV46.Count - 1] : string.Empty;
        }

        public IReadOnlyList<string> AllEntriesV46()
        {
            return _entriesV46.AsReadOnly();
        }
    }
}
