using System;
using System.Collections.Generic;

namespace ColdStorageOps
{
    public class StorageEntryV45
    {
        private string _palletIdFieldV45 = string.Empty;
        public string PalletIdV45 { get { return _palletIdFieldV45; } set { _palletIdFieldV45 = value; } }
        public double TemperatureCelsiusV45 { get; set; }
    }

    public class ColdStorageLedgerV45
    {
        private readonly List<StorageEntryV45> _entriesV45 = new List<StorageEntryV45>();

        public void RecordV45(StorageEntryV45 entryV45)
        {
            if (entryV45.TemperatureCelsiusV45 > -15)
            {
                throw new InvalidOperationException("Pallet above safe frozen threshold");
            }
            _entriesV45.Add(entryV45);
        }

        public int Count() { return _entriesV45.Count; }

        public double AverageTemperatureV45()
        {
            if (_entriesV45.Count == 0)
            {
                return 0;
            }
            double totalV45 = 0;
            foreach (var entryV45 in _entriesV45)
            {
                totalV45 += entryV45.TemperatureCelsiusV45;
            }
            return totalV45 / _entriesV45.Count;
        }
    }
}
