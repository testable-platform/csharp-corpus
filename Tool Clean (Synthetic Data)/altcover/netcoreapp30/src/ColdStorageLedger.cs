using System;
using System.Collections.Generic;

namespace ColdStorageOps
{
    public class StorageEntryV30
    {
        public string PalletIdV30 { get; set; } = string.Empty;
        public double TemperatureCelsiusV30 { get; set; }
    }

    public class ColdStorageLedgerV30
    {
        private readonly List<StorageEntryV30> _entriesV30 = new List<StorageEntryV30>();

        public void RecordV30(StorageEntryV30 entryV30)
        {
            if (entryV30.TemperatureCelsiusV30 > -15)
            {
                throw new InvalidOperationException("Pallet above safe frozen threshold");
            }
            _entriesV30.Add(entryV30);
        }

        public int Count() => _entriesV30.Count;

        public double AverageTemperatureV30()
        {
            if (_entriesV30.Count == 0)
            {
                return 0;
            }
            double totalV30 = 0;
            foreach (var entryV30 in _entriesV30)
            {
                totalV30 += entryV30.TemperatureCelsiusV30;
            }
            return totalV30 / _entriesV30.Count;
        }
    }
}
