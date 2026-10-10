using System;
using System.Collections.Generic;

namespace AviaryOps
{
    public class ClutchRecordV30
    {
        public string SpeciesCodeV30 { get; set; } = string.Empty;
        public int EggCountV30 { get; set; }
        public int HatchedCountV30 { get; set; }
    }

    public class AviaryBreedingRecordV30
    {
        private readonly List<ClutchRecordV30> _clutchesV30 = new List<ClutchRecordV30>();

        public void Add(ClutchRecordV30 clutchV30)
        {
            if (clutchV30.HatchedCountV30 > clutchV30.EggCountV30)
            {
                throw new ArgumentException("Hatched count cannot exceed egg count");
            }
            _clutchesV30.Add(clutchV30);
        }

        public double HatchRateV30()
        {
            int eggsV30 = 0;
            int hatchedV30 = 0;
            foreach (var clutchV30 in _clutchesV30)
            {
                eggsV30 += clutchV30.EggCountV30;
                hatchedV30 += clutchV30.HatchedCountV30;
            }
            return eggsV30 == 0 ? 0 : (double)hatchedV30 / eggsV30;
        }

        public int Count() => _clutchesV30.Count;
    }
}
