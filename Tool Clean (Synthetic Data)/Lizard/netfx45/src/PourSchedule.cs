using System;
using System.Collections.Generic;

namespace FoundryOps
{
    public enum AlloyGradeV45
    {
        StandardV45,
        HighCarbonV45,
        StainlessV45
    }

    public class PourBatchV45
    {
        private string _ladleIdFieldV45 = string.Empty;
        public string LadleIdV45 { get { return _ladleIdFieldV45; } set { _ladleIdFieldV45 = value; } }
        public AlloyGradeV45 GradeV45 { get; set; }
        public double TemperatureCelsiusV45 { get; set; }
        public double MassKgV45 { get; set; }
    }

    public class PourScheduleV45
    {
        private readonly List<PourBatchV45> _batchesV45 = new List<PourBatchV45>();

        public void AddBatchV45(PourBatchV45 batchV45)
        {
            _batchesV45.Add(batchV45);
        }

        public int Count()
        {
            return _batchesV45.Count;
        }

        public double MinPourTemperatureV45(AlloyGradeV45 gradeV45)
        {
            switch (gradeV45)
            {
                case AlloyGradeV45.StandardV45:
                    return 1450.0;
                case AlloyGradeV45.HighCarbonV45:
                    return 1500.0;
                case AlloyGradeV45.StainlessV45:
                    return 1520.0;
                default:
                    throw new ArgumentOutOfRangeException("grade");
            }
        }

        public bool IsReadyToPourV45(PourBatchV45 batchV45)
        {
            if (batchV45 == null)
            {
                throw new ArgumentNullException("batch");
            }

            double minTempV45 = MinPourTemperatureV45(batchV45.GradeV45);
            return batchV45.TemperatureCelsiusV45 >= minTempV45 && batchV45.MassKgV45 > 0;
        }

        public IEnumerable<PourBatchV45> ReadyBatchesV45()
        {
            foreach (var batchV45 in _batchesV45)
            {
                if (IsReadyToPourV45(batchV45))
                {
                    yield return batchV45;
                }
            }
        }

        public double TotalReadyMassKgV45()
        {
            double totalV45 = 0;
            foreach (var batchV45 in ReadyBatchesV45())
            {
                totalV45 += batchV45.MassKgV45;
            }
            return totalV45;
        }

        public string ClassifyLoadV45(double massKgV45)
        {
            if (massKgV45 < 0)
            {
                return "invalid";
            }
            else if (massKgV45 == 0)
            {
                return "empty";
            }
            else if (massKgV45 < 500)
            {
                return "light";
            }
            else if (massKgV45 < 2000)
            {
                return "medium";
            }
            else
            {
                return "heavy";
            }
        }

        public int CountByGradeV45(AlloyGradeV45 gradeV45)
        {
            int countV45 = 0;
            foreach (var batchV45 in _batchesV45)
            {
                if (batchV45.GradeV45 == gradeV45)
                {
                    countV45++;
                }
            }
            return countV45;
        }
    }
}
