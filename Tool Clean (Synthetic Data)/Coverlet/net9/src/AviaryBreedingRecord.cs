using System;
using System.Collections.Generic;

namespace AviaryOps
{
    public class ClutchRecordV9
    {
        public string SpeciesCodeV9 { get; set; } = string.Empty;
        public int EggCountV9 { get; set; }
        public int HatchedCountV9 { get; set; }
    }

    public class AviaryBreedingRecordV9
    {
        private readonly List<ClutchRecordV9> _clutchesV9 = new List<ClutchRecordV9>();

        public void Add(ClutchRecordV9 clutchV9)
        {
            if (clutchV9.HatchedCountV9 > clutchV9.EggCountV9)
            {
                throw new ArgumentException("Hatched count cannot exceed egg count");
            }
            _clutchesV9.Add(clutchV9);
        }

        public double HatchRateV9()
        {
            int eggsV9 = 0;
            int hatchedV9 = 0;
            foreach (var clutchV9 in _clutchesV9)
            {
                eggsV9 += clutchV9.EggCountV9;
                hatchedV9 += clutchV9.HatchedCountV9;
            }
            return eggsV9 == 0 ? 0 : (double)hatchedV9 / eggsV9;
        }

        public int Count() => _clutchesV9.Count;
    }
}
