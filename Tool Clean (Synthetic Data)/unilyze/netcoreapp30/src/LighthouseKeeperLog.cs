using System;
using System.Collections.Generic;

namespace Coastal.Lighthouse
{
    /// <summary>
    /// Synthetic, clean-by-design domain for unilyze: a lighthouse keeper's
    /// shift log. Every method is short, shallow and single-purpose -- well
    /// under unilyze's own default smell thresholds.
    /// </summary>
    public sealed class LighthouseKeeperLogV30
    {
        private readonly List<string> _entriesV30 = new List<string>();

        public int EntryCountV30 => _entriesV30.Count;

        public void RecordV30(string keeperNameV30, string observationV30)
        {
            if (string.IsNullOrWhiteSpace(keeperNameV30))
            {
                throw new ArgumentException("keeperName is required", nameof(keeperNameV30));
            }

            _entriesV30.Add(FormatEntryV30(keeperNameV30, observationV30));
        }

        private static string FormatEntryV30(string keeperNameV30, string observationV30)
        {
            var timestampV30 = DateTime.UtcNow.ToString("u");
            return $"[{timestampV30}] {keeperNameV30}: {observationV30}";
        }

        public bool HasEntriesV30()
        {
            return _entriesV30.Count > 0;
        }

        public string LatestEntryV30()
        {
            return HasEntriesV30() ? _entriesV30[_entriesV30.Count - 1] : string.Empty;
        }

        public IReadOnlyList<string> AllEntriesV30()
        {
            return _entriesV30.AsReadOnly();
        }
    }
}
