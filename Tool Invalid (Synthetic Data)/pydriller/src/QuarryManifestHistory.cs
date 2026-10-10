using System;
using System.Collections.Generic;

namespace ManifestOps
{
    // schema version 2
    public class ManifestRecord
    {
        public string ManifestId { get; set; } = string.Empty;
        public double TonnesLogged { get; set; }
    }

    public class QuarryManifestHistory
    {
        private readonly List<ManifestRecord> _records = new List<ManifestRecord>();

        public void Record(ManifestRecord record)
        {
            _records.Add(record);
        }

        public int Count()
        {
            return _records.Count;
        }

        public ManifestRecord FindByManifestId(string manifestId)
        {
            foreach (var record in _records)
            {
                if (record.ManifestId == manifestId)
                {
                    return record;
                }
            }
            return null;
        }

        public double TotalTonnes()
        {
            double total = 0;
            foreach (var record in _records)
            {
                total += record.TonnesLogged;
            }
            return total;
        }
    }
}
