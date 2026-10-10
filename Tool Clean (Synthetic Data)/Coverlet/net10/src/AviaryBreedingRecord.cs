using System;
using System.Collections.Generic;

namespace AviaryOps
{
    public class ClutchRecord
    {
        public string SpeciesCode { get; set; } = string.Empty;
        public int EggCount { get; set; }
        public int HatchedCount { get; set; }
    }

    public class AviaryBreedingRecord
    {
        private readonly List<ClutchRecord> _clutches = new List<ClutchRecord>();

        public void Add(ClutchRecord clutch)
        {
            if (clutch.HatchedCount > clutch.EggCount)
            {
                throw new ArgumentException("Hatched count cannot exceed egg count");
            }
            _clutches.Add(clutch);
        }

        public double HatchRate()
        {
            int eggs = 0;
            int hatched = 0;
            foreach (var clutch in _clutches)
            {
                eggs += clutch.EggCount;
                hatched += clutch.HatchedCount;
            }
            return eggs == 0 ? 0 : (double)hatched / eggs;
        }

        public int Count() => _clutches.Count;
    }
}
