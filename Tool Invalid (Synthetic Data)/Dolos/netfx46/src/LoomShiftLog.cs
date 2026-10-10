using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class LoomShiftEntry
    {
        public string LoomId { get; set; } = string.Empty;
        public int MetersWoven { get; set; }
    }

    public class LoomShiftLog
    {
        private readonly List<LoomShiftEntry> _entries = new List<LoomShiftEntry>();

        public void Log(LoomShiftEntry entry)
        {
            _entries.Add(entry);
        }

        public int Count()
        {
            return _entries.Count;
        }

        public int TotalMetersWoven()
        {
            int total = 0;
            foreach (var entry in _entries)
            {
                total += entry.MetersWoven;
            }
            return total;
        }
    }
}
