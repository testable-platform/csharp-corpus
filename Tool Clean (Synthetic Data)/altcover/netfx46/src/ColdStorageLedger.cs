using System;
using System.Collections.Generic;

namespace ColdStorageOps
{
    public class StorageEntryV46
    {
        public string PalletIdV46 { get; set; } = string.Empty;
        public double TemperatureCelsiusV46 { get; set; }
    }

    public class ColdStorageLedgerV46
    {
        private readonly List<StorageEntryV46> _entriesV46 = new List<StorageEntryV46>();

        public void RecordV46(StorageEntryV46 entryV46)
        {
            if (entryV46.TemperatureCelsiusV46 > -15)
            {
                throw new InvalidOperationException("Pallet above safe frozen threshold");
            }
            _entriesV46.Add(entryV46);
        }

        public int Count() => _entriesV46.Count;

        public double AverageTemperatureV46()
        {
            if (_entriesV46.Count == 0)
            {
                return 0;
            }
            double totalV46 = 0;
            foreach (var entryV46 in _entriesV46)
            {
                totalV46 += entryV46.TemperatureCelsiusV46;
            }
            return totalV46 / _entriesV46.Count;
        }
    }
}
