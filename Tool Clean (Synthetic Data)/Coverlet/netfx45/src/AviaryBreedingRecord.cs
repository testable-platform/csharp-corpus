using System;
using System.Collections.Generic;

namespace AviaryOps
{
    public class ClutchRecordV45
    {
        private string _speciesCodeFieldV45 = string.Empty;
        public string SpeciesCodeV45 { get { return _speciesCodeFieldV45; } set { _speciesCodeFieldV45 = value; } }
        public int EggCountV45 { get; set; }
        public int HatchedCountV45 { get; set; }
    }

    public class AviaryBreedingRecordV45
    {
        private readonly List<ClutchRecordV45> _clutchesV45 = new List<ClutchRecordV45>();

        public void Add(ClutchRecordV45 clutchV45)
        {
            if (clutchV45.HatchedCountV45 > clutchV45.EggCountV45)
            {
                throw new ArgumentException("Hatched count cannot exceed egg count");
            }
            _clutchesV45.Add(clutchV45);
        }

        public double HatchRateV45()
        {
            int eggsV45 = 0;
            int hatchedV45 = 0;
            foreach (var clutchV45 in _clutchesV45)
            {
                eggsV45 += clutchV45.EggCountV45;
                hatchedV45 += clutchV45.HatchedCountV45;
            }
            return eggsV45 == 0 ? 0 : (double)hatchedV45 / eggsV45;
        }

        public int Count() { return _clutchesV45.Count; }
    }
}
