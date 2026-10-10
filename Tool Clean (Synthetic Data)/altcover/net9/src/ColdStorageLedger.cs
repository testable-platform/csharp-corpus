using System;
using System.Collections.Generic;

namespace ColdStorageOps
{
    public class StorageEntryV9
    {
        public string PalletIdV9 { get; set; } = string.Empty;
        public double TemperatureCelsiusV9 { get; set; }
    }

    public class ColdStorageLedgerV9
    {
        private readonly List<StorageEntryV9> _entriesV9 = new List<StorageEntryV9>();

        public void RecordV9(StorageEntryV9 entryV9)
        {
            if (entryV9.TemperatureCelsiusV9 > -15)
            {
                throw new InvalidOperationException("Pallet above safe frozen threshold");
            }
            _entriesV9.Add(entryV9);
        }

        public int Count() => _entriesV9.Count;

        public double AverageTemperatureV9()
        {
            if (_entriesV9.Count == 0)
            {
                return 0;
            }
            double totalV9 = 0;
            foreach (var entryV9 in _entriesV9)
            {
                totalV9 += entryV9.TemperatureCelsiusV9;
            }
            return totalV9 / _entriesV9.Count;
        }
    }
}
