using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class LoomShiftEntry
    {
        private string _loomIdField = string.Empty;
        public string LoomId { get { return _loomIdField; } set { _loomIdField = value; } }
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
