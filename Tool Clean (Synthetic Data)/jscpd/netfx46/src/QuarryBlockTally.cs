using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class GraniteBlockV46
    {
        public string BlockIdV46 { get; set; } = string.Empty;
        public double VolumeCubicMetersV46 { get; set; }
        public double DensityKgPerM3V46 { get; set; }
    }

    public class QuarryBlockTallyV46
    {
        private readonly List<GraniteBlockV46> _blocksV46 = new List<GraniteBlockV46>();

        public void RegisterV46(GraniteBlockV46 blockV46)
        {
            _blocksV46.Add(blockV46);
        }

        public double MassKgV46(GraniteBlockV46 blockV46)
        {
            return blockV46.VolumeCubicMetersV46 * blockV46.DensityKgPerM3V46;
        }

        public double TotalMassKgV46()
        {
            double totalV46 = 0;
            foreach (var blockV46 in _blocksV46)
            {
                totalV46 += MassKgV46(blockV46);
            }
            return totalV46;
        }

        public int Count()
        {
            return _blocksV46.Count;
        }

        public GraniteBlockV46 HeaviestBlockV46()
        {
            GraniteBlockV46 heaviestV46 = null;
            double heaviestMassV46 = -1;
            foreach (var blockV46 in _blocksV46)
            {
                double massV46 = MassKgV46(blockV46);
                if (massV46 > heaviestMassV46)
                {
                    heaviestMassV46 = massV46;
                    heaviestV46 = blockV46;
                }
            }
            return heaviestV46;
        }

        public List<GraniteBlockV46> AboveThresholdV46(double thresholdKgV46)
        {
            var resultV46 = new List<GraniteBlockV46>();
            foreach (var blockV46 in _blocksV46)
            {
                if (MassKgV46(blockV46) > thresholdKgV46)
                {
                    resultV46.Add(blockV46);
                }
            }
            return resultV46;
        }
    }
}
