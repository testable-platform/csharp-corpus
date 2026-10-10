using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class GraniteBlockV30
    {
        public string BlockIdV30 { get; set; } = string.Empty;
        public double VolumeCubicMetersV30 { get; set; }
        public double DensityKgPerM3V30 { get; set; }
    }

    public class QuarryBlockTallyV30
    {
        private readonly List<GraniteBlockV30> _blocksV30 = new List<GraniteBlockV30>();

        public void RegisterV30(GraniteBlockV30 blockV30)
        {
            _blocksV30.Add(blockV30);
        }

        public double MassKgV30(GraniteBlockV30 blockV30)
        {
            return blockV30.VolumeCubicMetersV30 * blockV30.DensityKgPerM3V30;
        }

        public double TotalMassKgV30()
        {
            double totalV30 = 0;
            foreach (var blockV30 in _blocksV30)
            {
                totalV30 += MassKgV30(blockV30);
            }
            return totalV30;
        }

        public int Count()
        {
            return _blocksV30.Count;
        }

        public GraniteBlockV30 HeaviestBlockV30()
        {
            GraniteBlockV30 heaviestV30 = null;
            double heaviestMassV30 = -1;
            foreach (var blockV30 in _blocksV30)
            {
                double massV30 = MassKgV30(blockV30);
                if (massV30 > heaviestMassV30)
                {
                    heaviestMassV30 = massV30;
                    heaviestV30 = blockV30;
                }
            }
            return heaviestV30;
        }

        public List<GraniteBlockV30> AboveThresholdV30(double thresholdKgV30)
        {
            var resultV30 = new List<GraniteBlockV30>();
            foreach (var blockV30 in _blocksV30)
            {
                if (MassKgV30(blockV30) > thresholdKgV30)
                {
                    resultV30.Add(blockV30);
                }
            }
            return resultV30;
        }
    }
}
