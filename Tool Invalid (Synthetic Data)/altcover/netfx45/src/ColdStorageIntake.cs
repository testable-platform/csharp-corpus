using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class ColdStorageCrate
    {
        private string _crateIdField = string.Empty;
        public string CrateId { get { return _crateIdField; } set { _crateIdField = value; } }
        public double TemperatureCelsius { get; set; }
    }

    public class ColdStorageIntake
    {
        private readonly List<ColdStorageCrate> _crates = new List<ColdStorageCrate>();

        public void Intake(ColdStorageCrate crate)
        {
            _crates.Add(crate);
        }

        public int Count()
        {
            return _crates.Count;
        }

        public bool IsWithinRange(ColdStorageCrate crate, double minC, double maxC)
        {
            if (crate == null)
            {
                throw new ArgumentNullException("crate");
            }
            return crate.TemperatureCelsius >= minC && crate.TemperatureCelsius <= maxC;
        }

        public double AverageTemperature()
        {
            if (_crates.Count == 0)
            {
                return 0;
            }
            double total = 0;
            foreach (var crate in _crates)
            {
                total += crate.TemperatureCelsius;
            }
            return total / _crates.Count;
        }
    }
}
