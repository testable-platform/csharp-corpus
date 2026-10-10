using System;
using System.Collections.Generic;

namespace AviaryOps
{
    public class ClutchRecordV46
    {
        public string SpeciesCodeV46 { get; set; } = string.Empty;
        public int EggCountV46 { get; set; }
        public int HatchedCountV46 { get; set; }
    }

    public class AviaryBreedingRecordV46
    {
        private readonly List<ClutchRecordV46> _clutchesV46 = new List<ClutchRecordV46>();

        public void Add(ClutchRecordV46 clutchV46)
        {
            if (clutchV46.HatchedCountV46 > clutchV46.EggCountV46)
            {
                throw new ArgumentException("Hatched count cannot exceed egg count");
            }
            _clutchesV46.Add(clutchV46);
        }

        public double HatchRateV46()
        {
            int eggsV46 = 0;
            int hatchedV46 = 0;
            foreach (var clutchV46 in _clutchesV46)
            {
                eggsV46 += clutchV46.EggCountV46;
                hatchedV46 += clutchV46.HatchedCountV46;
            }
            return eggsV46 == 0 ? 0 : (double)hatchedV46 / eggsV46;
        }

        public int Count() => _clutchesV46.Count;
    }
}
