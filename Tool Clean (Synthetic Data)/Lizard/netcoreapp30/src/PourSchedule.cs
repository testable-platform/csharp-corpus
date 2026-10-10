using System;
using System.Collections.Generic;

namespace FoundryOps
{
    public enum AlloyGradeV30
    {
        StandardV30,
        HighCarbonV30,
        StainlessV30
    }

    public class PourBatchV30
    {
        public string LadleIdV30 { get; set; } = string.Empty;
        public AlloyGradeV30 GradeV30 { get; set; }
        public double TemperatureCelsiusV30 { get; set; }
        public double MassKgV30 { get; set; }
    }

    public class PourScheduleV30
    {
        private readonly List<PourBatchV30> _batchesV30 = new List<PourBatchV30>();

        public void AddBatchV30(PourBatchV30 batchV30)
        {
            _batchesV30.Add(batchV30);
        }

        public int Count()
        {
            return _batchesV30.Count;
        }

        public double MinPourTemperatureV30(AlloyGradeV30 gradeV30)
        {
            switch (gradeV30)
            {
                case AlloyGradeV30.StandardV30:
                    return 1450.0;
                case AlloyGradeV30.HighCarbonV30:
                    return 1500.0;
                case AlloyGradeV30.StainlessV30:
                    return 1520.0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gradeV30));
            }
        }

        public bool IsReadyToPourV30(PourBatchV30 batchV30)
        {
            if (batchV30 == null)
            {
                throw new ArgumentNullException(nameof(batchV30));
            }

            double minTempV30 = MinPourTemperatureV30(batchV30.GradeV30);
            return batchV30.TemperatureCelsiusV30 >= minTempV30 && batchV30.MassKgV30 > 0;
        }

        public IEnumerable<PourBatchV30> ReadyBatchesV30()
        {
            foreach (var batchV30 in _batchesV30)
            {
                if (IsReadyToPourV30(batchV30))
                {
                    yield return batchV30;
                }
            }
        }

        public double TotalReadyMassKgV30()
        {
            double totalV30 = 0;
            foreach (var batchV30 in ReadyBatchesV30())
            {
                totalV30 += batchV30.MassKgV30;
            }
            return totalV30;
        }

        public string ClassifyLoadV30(double massKgV30)
        {
            if (massKgV30 < 0)
            {
                return "invalid";
            }
            else if (massKgV30 == 0)
            {
                return "empty";
            }
            else if (massKgV30 < 500)
            {
                return "light";
            }
            else if (massKgV30 < 2000)
            {
                return "medium";
            }
            else
            {
                return "heavy";
            }
        }

        public int CountByGradeV30(AlloyGradeV30 gradeV30)
        {
            int countV30 = 0;
            foreach (var batchV30 in _batchesV30)
            {
                if (batchV30.GradeV30 == gradeV30)
                {
                    countV30++;
                }
            }
            return countV30;
        }
    }
}
