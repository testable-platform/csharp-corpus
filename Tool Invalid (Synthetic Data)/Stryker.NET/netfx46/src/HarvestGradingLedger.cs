using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class HarvestLot
    {
        public string LotId { get; set; } = string.Empty;
        public double QualityScore { get; set; }
    }

    public class HarvestGradingLedger
    {
        private readonly List<HarvestLot> _lots = new List<HarvestLot>();

        public void Record(HarvestLot lot)
        {
            _lots.Add(lot);
        }

        public int Count()
        {
            return _lots.Count;
        }

        public string GradeFor(double qualityScore)
        {
            if (qualityScore >= 90)
            {
                return "premium";
            }
            else if (qualityScore >= 70)
            {
                return "standard";
            }
            else
            {
                return "reject";
            }
        }
    }
}
