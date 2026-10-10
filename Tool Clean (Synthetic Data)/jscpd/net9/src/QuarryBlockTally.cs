using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class GraniteBlockV9
    {
        public string BlockIdV9 { get; set; } = string.Empty;
        public double VolumeCubicMetersV9 { get; set; }
        public double DensityKgPerM3V9 { get; set; }
    }

    public class QuarryBlockTallyV9
    {
        private readonly List<GraniteBlockV9> _blocksV9 = new List<GraniteBlockV9>();

        public void RegisterV9(GraniteBlockV9 blockV9)
        {
            _blocksV9.Add(blockV9);
        }

        public double MassKgV9(GraniteBlockV9 blockV9)
        {
            return blockV9.VolumeCubicMetersV9 * blockV9.DensityKgPerM3V9;
        }

        public double TotalMassKgV9()
        {
            double totalV9 = 0;
            foreach (var blockV9 in _blocksV9)
            {
                totalV9 += MassKgV9(blockV9);
            }
            return totalV9;
        }

        public int Count()
        {
            return _blocksV9.Count;
        }

        public GraniteBlockV9 HeaviestBlockV9()
        {
            GraniteBlockV9 heaviestV9 = null;
            double heaviestMassV9 = -1;
            foreach (var blockV9 in _blocksV9)
            {
                double massV9 = MassKgV9(blockV9);
                if (massV9 > heaviestMassV9)
                {
                    heaviestMassV9 = massV9;
                    heaviestV9 = blockV9;
                }
            }
            return heaviestV9;
        }

        public List<GraniteBlockV9> AboveThresholdV9(double thresholdKgV9)
        {
            var resultV9 = new List<GraniteBlockV9>();
            foreach (var blockV9 in _blocksV9)
            {
                if (MassKgV9(blockV9) > thresholdKgV9)
                {
                    resultV9.Add(blockV9);
                }
            }
            return resultV9;
        }
    }
}
