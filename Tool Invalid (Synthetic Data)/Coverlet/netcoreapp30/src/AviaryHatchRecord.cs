using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class HatchRecord
    {
        public string ClutchId { get; set; } = string.Empty;
        public int EggCount { get; set; }
    }

    public class AviaryHatchRecord
    {
        private readonly List<HatchRecord> _clutches = new List<HatchRecord>();

        public void Register(HatchRecord record)
        {
            _clutches.Add(record);
        }

        public int Count()
        {
            return _clutches.Count;
        }

        public int TotalEggs()
        {
            int total = 0;
            foreach (var record in _clutches)
            {
                total += record.EggCount;
            }
            return total;
        }

        public HatchRecord FindByClutchId(string clutchId)
        {
            foreach (var record in _clutches)
            {
                if (record.ClutchId == clutchId)
                {
                    return record;
                }
            }
            return null;
        }
    }
}
