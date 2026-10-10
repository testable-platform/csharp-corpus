using System;
using System.Collections.Generic;

namespace FoundryOps
{
    public enum AlloyGradeV9
    {
        StandardV9,
        HighCarbonV9,
        StainlessV9
    }

    public class PourBatchV9
    {
        public string LadleIdV9 { get; set; } = string.Empty;
        public AlloyGradeV9 GradeV9 { get; set; }
        public double TemperatureCelsiusV9 { get; set; }
        public double MassKgV9 { get; set; }
    }

    public class PourScheduleV9
    {
        private readonly List<PourBatchV9> _batchesV9 = new List<PourBatchV9>();

        public void AddBatchV9(PourBatchV9 batchV9)
        {
            _batchesV9.Add(batchV9);
        }

        public int Count()
        {
            return _batchesV9.Count;
        }

        public double MinPourTemperatureV9(AlloyGradeV9 gradeV9)
        {
            switch (gradeV9)
            {
                case AlloyGradeV9.StandardV9:
                    return 1450.0;
                case AlloyGradeV9.HighCarbonV9:
                    return 1500.0;
                case AlloyGradeV9.StainlessV9:
                    return 1520.0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gradeV9));
            }
        }

        public bool IsReadyToPourV9(PourBatchV9 batchV9)
        {
            if (batchV9 == null)
            {
                throw new ArgumentNullException(nameof(batchV9));
            }

            double minTempV9 = MinPourTemperatureV9(batchV9.GradeV9);
            return batchV9.TemperatureCelsiusV9 >= minTempV9 && batchV9.MassKgV9 > 0;
        }

        public IEnumerable<PourBatchV9> ReadyBatchesV9()
        {
            foreach (var batchV9 in _batchesV9)
            {
                if (IsReadyToPourV9(batchV9))
                {
                    yield return batchV9;
                }
            }
        }

        public double TotalReadyMassKgV9()
        {
            double totalV9 = 0;
            foreach (var batchV9 in ReadyBatchesV9())
            {
                totalV9 += batchV9.MassKgV9;
            }
            return totalV9;
        }

        public string ClassifyLoadV9(double massKgV9)
        {
            if (massKgV9 < 0)
            {
                return "invalid";
            }
            else if (massKgV9 == 0)
            {
                return "empty";
            }
            else if (massKgV9 < 500)
            {
                return "light";
            }
            else if (massKgV9 < 2000)
            {
                return "medium";
            }
            else
            {
                return "heavy";
            }
        }

        public int CountByGradeV9(AlloyGradeV9 gradeV9)
        {
            int countV9 = 0;
            foreach (var batchV9 in _batchesV9)
            {
                if (batchV9.GradeV9 == gradeV9)
                {
                    countV9++;
                }
            }
            return countV9;
        }
    }
}
