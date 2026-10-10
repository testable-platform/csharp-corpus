using System;
using System.Collections.Generic;

namespace ColdStorageOps
{
    public class StorageEntry
    {
        public string PalletId { get; set; } = string.Empty;
        public double TemperatureCelsius { get; set; }
    }

    public class ColdStorageLedger
    {
        private readonly List<StorageEntry> _entries = new List<StorageEntry>();

        public void Record(StorageEntry entry)
        {
            if (entry.TemperatureCelsius > -15)
            {
                throw new InvalidOperationException("Pallet above safe frozen threshold");
            }
            _entries.Add(entry);
        }

        public int Count() => _entries.Count;

        public double AverageTemperature()
        {
            if (_entries.Count == 0)
            {
                return 0;
            }
            double total = 0;
            foreach (var entry in _entries)
            {
                total += entry.TemperatureCelsius;
            }
            return total / _entries.Count;
        }
    }
}
