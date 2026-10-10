using System;
using System.Collections.Generic;

namespace Coastal.Lighthouse
{
    /// <summary>
    /// Synthetic, clean-by-design domain for unilyze: a lighthouse keeper's
    /// shift log. Every method is short, shallow and single-purpose -- well
    /// under unilyze's own default smell thresholds.
    /// </summary>
    public sealed class LighthouseKeeperLog
    {
        private readonly List<string> _entries = new List<string>();

        public int EntryCount => _entries.Count;

        public void Record(string keeperName, string observation)
        {
            if (string.IsNullOrWhiteSpace(keeperName))
            {
                throw new ArgumentException("keeperName is required", nameof(keeperName));
            }

            _entries.Add(FormatEntry(keeperName, observation));
        }

        private static string FormatEntry(string keeperName, string observation)
        {
            var timestamp = DateTime.UtcNow.ToString("u");
            return $"[{timestamp}] {keeperName}: {observation}";
        }

        public bool HasEntries()
        {
            return _entries.Count > 0;
        }

        public string LatestEntry()
        {
            return HasEntries() ? _entries[_entries.Count - 1] : string.Empty;
        }

        public IReadOnlyList<string> AllEntries()
        {
            return _entries.AsReadOnly();
        }
    }
}
