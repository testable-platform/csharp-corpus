using System;
using System.Collections.Generic;

namespace FoundryOps
{
    public enum AlloyGrade
    {
        Standard,
        HighCarbon,
        Stainless
    }

    public class PourBatch
    {
        public string LadleId { get; set; } = string.Empty;
        public AlloyGrade Grade { get; set; }
        public double TemperatureCelsius { get; set; }
        public double MassKg { get; set; }
    }

    public class PourSchedule
    {
        private readonly List<PourBatch> _batches = new List<PourBatch>();

        public void AddBatch(PourBatch batch)
        {
            _batches.Add(batch);
        }

        public int Count()
        {
            return _batches.Count;
        }

        public double MinPourTemperature(AlloyGrade grade)
        {
            switch (grade)
            {
                case AlloyGrade.Standard:
                    return 1450.0;
                case AlloyGrade.HighCarbon:
                    return 1500.0;
                case AlloyGrade.Stainless:
                    return 1520.0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(grade));
            }
        }

        public bool IsReadyToPour(PourBatch batch)
        {
            if (batch == null)
            {
                throw new ArgumentNullException(nameof(batch));
            }

            double minTemp = MinPourTemperature(batch.Grade);
            return batch.TemperatureCelsius >= minTemp && batch.MassKg > 0;
        }

        public IEnumerable<PourBatch> ReadyBatches()
        {
            foreach (var batch in _batches)
            {
                if (IsReadyToPour(batch))
                {
                    yield return batch;
                }
            }
        }

        public double TotalReadyMassKg()
        {
            double total = 0;
            foreach (var batch in ReadyBatches())
            {
                total += batch.MassKg;
            }
            return total;
        }

        public string ClassifyLoad(double massKg)
        {
            if (massKg < 0)
            {
                return "invalid";
            }
            else if (massKg == 0)
            {
                return "empty";
            }
            else if (massKg < 500)
            {
                return "light";
            }
            else if (massKg < 2000)
            {
                return "medium";
            }
            else
            {
                return "heavy";
            }
        }

        public int CountByGrade(AlloyGrade grade)
        {
            int count = 0;
            foreach (var batch in _batches)
            {
                if (batch.Grade == grade)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
