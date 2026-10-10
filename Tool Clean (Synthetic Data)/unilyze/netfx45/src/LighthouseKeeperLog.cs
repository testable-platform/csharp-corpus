using System;
using System.Collections.Generic;

namespace Coastal.Lighthouse
{
    /// <summary>
    /// Synthetic, clean-by-design domain for unilyze: a lighthouse keeper's
    /// shift log. Every method is short, shallow and single-purpose -- well
    /// under unilyze's own default smell thresholds.
    /// </summary>
    public sealed class LighthouseKeeperLogV45
    {
        private readonly List<string> _entriesV45 = new List<string>();

        public int EntryCountV45 { get { return _entriesV45.Count; } }

        public void RecordV45(string keeperNameV45, string observationV45)
        {
            if (string.IsNullOrWhiteSpace(keeperNameV45))
            {
                throw new ArgumentException("keeperName is required", "keeperName");
            }

            _entriesV45.Add(FormatEntryV45(keeperNameV45, observationV45));
        }

        private static string FormatEntryV45(string keeperNameV45, string observationV45)
        {
            var timestampV45 = DateTime.UtcNow.ToString("u");
            return string.Format("[{0}] {1}: {2}", timestampV45, keeperNameV45, observationV45);
        }

        public bool HasEntriesV45()
        {
            return _entriesV45.Count > 0;
        }

        public string LatestEntryV45()
        {
            return HasEntriesV45() ? _entriesV45[_entriesV45.Count - 1] : string.Empty;
        }

        public IReadOnlyList<string> AllEntriesV45()
        {
            return _entriesV45.AsReadOnly();
        }
    }
}
