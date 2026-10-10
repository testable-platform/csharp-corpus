using System;
using System.Collections.Generic;

namespace FoundryOps
{
    public enum AlloyGradeV46
    {
        StandardV46,
        HighCarbonV46,
        StainlessV46
    }

    public class PourBatchV46
    {
        public string LadleIdV46 { get; set; } = string.Empty;
        public AlloyGradeV46 GradeV46 { get; set; }
        public double TemperatureCelsiusV46 { get; set; }
        public double MassKgV46 { get; set; }
    }

    public class PourScheduleV46
    {
        private readonly List<PourBatchV46> _batchesV46 = new List<PourBatchV46>();

        public void AddBatchV46(PourBatchV46 batchV46)
        {
            _batchesV46.Add(batchV46);
        }

        public int Count()
        {
            return _batchesV46.Count;
        }

        public double MinPourTemperatureV46(AlloyGradeV46 gradeV46)
        {
            switch (gradeV46)
            {
                case AlloyGradeV46.StandardV46:
                    return 1450.0;
                case AlloyGradeV46.HighCarbonV46:
                    return 1500.0;
                case AlloyGradeV46.StainlessV46:
                    return 1520.0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gradeV46));
            }
        }

        public bool IsReadyToPourV46(PourBatchV46 batchV46)
        {
            if (batchV46 == null)
            {
                throw new ArgumentNullException(nameof(batchV46));
            }

            double minTempV46 = MinPourTemperatureV46(batchV46.GradeV46);
            return batchV46.TemperatureCelsiusV46 >= minTempV46 && batchV46.MassKgV46 > 0;
        }

        public IEnumerable<PourBatchV46> ReadyBatchesV46()
        {
            foreach (var batchV46 in _batchesV46)
            {
                if (IsReadyToPourV46(batchV46))
                {
                    yield return batchV46;
                }
            }
        }

        public double TotalReadyMassKgV46()
        {
            double totalV46 = 0;
            foreach (var batchV46 in ReadyBatchesV46())
            {
                totalV46 += batchV46.MassKgV46;
            }
            return totalV46;
        }

        public string ClassifyLoadV46(double massKgV46)
        {
            if (massKgV46 < 0)
            {
                return "invalid";
            }
            else if (massKgV46 == 0)
            {
                return "empty";
            }
            else if (massKgV46 < 500)
            {
                return "light";
            }
            else if (massKgV46 < 2000)
            {
                return "medium";
            }
            else
            {
                return "heavy";
            }
        }

        public int CountByGradeV46(AlloyGradeV46 gradeV46)
        {
            int countV46 = 0;
            foreach (var batchV46 in _batchesV46)
            {
                if (batchV46.GradeV46 == gradeV46)
                {
                    countV46++;
                }
            }
            return countV46;
        }
    }
}
