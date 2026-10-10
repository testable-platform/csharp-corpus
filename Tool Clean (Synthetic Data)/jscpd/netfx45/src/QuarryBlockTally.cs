using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class GraniteBlockV45
    {
        private string _blockIdFieldV45 = string.Empty;
        public string BlockIdV45 { get { return _blockIdFieldV45; } set { _blockIdFieldV45 = value; } }
        public double VolumeCubicMetersV45 { get; set; }
        public double DensityKgPerM3V45 { get; set; }
    }

    public class QuarryBlockTallyV45
    {
        private readonly List<GraniteBlockV45> _blocksV45 = new List<GraniteBlockV45>();

        public void RegisterV45(GraniteBlockV45 blockV45)
        {
            _blocksV45.Add(blockV45);
        }

        public double MassKgV45(GraniteBlockV45 blockV45)
        {
            return blockV45.VolumeCubicMetersV45 * blockV45.DensityKgPerM3V45;
        }

        public double TotalMassKgV45()
        {
            double totalV45 = 0;
            foreach (var blockV45 in _blocksV45)
            {
                totalV45 += MassKgV45(blockV45);
            }
            return totalV45;
        }

        public int Count()
        {
            return _blocksV45.Count;
        }

        public GraniteBlockV45 HeaviestBlockV45()
        {
            GraniteBlockV45 heaviestV45 = null;
            double heaviestMassV45 = -1;
            foreach (var blockV45 in _blocksV45)
            {
                double massV45 = MassKgV45(blockV45);
                if (massV45 > heaviestMassV45)
                {
                    heaviestMassV45 = massV45;
                    heaviestV45 = blockV45;
                }
            }
            return heaviestV45;
        }

        public List<GraniteBlockV45> AboveThresholdV45(double thresholdKgV45)
        {
            var resultV45 = new List<GraniteBlockV45>();
            foreach (var blockV45 in _blocksV45)
            {
                if (MassKgV45(blockV45) > thresholdKgV45)
                {
                    resultV45.Add(blockV45);
                }
            }
            return resultV45;
        }
    }
}
