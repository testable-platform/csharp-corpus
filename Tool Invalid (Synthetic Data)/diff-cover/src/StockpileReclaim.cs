using System;
using System.Collections.Generic;

namespace ReclaimOps
{
    public class StockpileEntry
    {
        public string StockpileId { get; set; } = string.Empty;
        public double Tonnes { get; set; }
    }

    public class StockpileReclaim
    {
        private readonly List<StockpileEntry> _entries = new();

        public void Register(StockpileEntry entry)
        {
            Cov.Mark("src/StockpileReclaim.cs");
            _entries.Add(entry);
        }

        public int Count()
        {
            Cov.Mark("src/StockpileReclaim.cs");
            return _entries.Count;
        }

        // New in `feature`: a 6-way tonnage classifier. The driver below
        // only exercises 2 of these 6 branches, so 4 of 6 new coverable
        // lines are genuinely never hit -- a real, measured diff-coverage
        // shortfall, not an asserted one.
        public string ClassifyStockpile(double tonnes)
        {
            if (tonnes < 0)
            {
                Cov.Mark("src/StockpileReclaim.cs");
                return "invalid";
            }
            else if (tonnes == 0)
            {
                Cov.Mark("src/StockpileReclaim.cs");
                return "empty";
            }
            else if (tonnes < 100)
            {
                Cov.Mark("src/StockpileReclaim.cs");
                return "small";
            }
            else if (tonnes < 500)
            {
                Cov.Mark("src/StockpileReclaim.cs");
                return "medium";
            }
            else if (tonnes < 2000)
            {
                Cov.Mark("src/StockpileReclaim.cs");
                return "large";
            }
            else
            {
                Cov.Mark("src/StockpileReclaim.cs");
                return "bulk";
            }
        }
    }
}
