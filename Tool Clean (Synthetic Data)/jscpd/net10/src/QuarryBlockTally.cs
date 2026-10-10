using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class GraniteBlock
    {
        public string BlockId { get; set; } = string.Empty;
        public double VolumeCubicMeters { get; set; }
        public double DensityKgPerM3 { get; set; }
    }

    public class QuarryBlockTally
    {
        private readonly List<GraniteBlock> _blocks = new List<GraniteBlock>();

        public void Register(GraniteBlock block)
        {
            _blocks.Add(block);
        }

        public double MassKg(GraniteBlock block)
        {
            return block.VolumeCubicMeters * block.DensityKgPerM3;
        }

        public double TotalMassKg()
        {
            double total = 0;
            foreach (var block in _blocks)
            {
                total += MassKg(block);
            }
            return total;
        }

        public int Count()
        {
            return _blocks.Count;
        }

        public GraniteBlock HeaviestBlock()
        {
            GraniteBlock heaviest = null;
            double heaviestMass = -1;
            foreach (var block in _blocks)
            {
                double mass = MassKg(block);
                if (mass > heaviestMass)
                {
                    heaviestMass = mass;
                    heaviest = block;
                }
            }
            return heaviest;
        }

        public List<GraniteBlock> AboveThreshold(double thresholdKg)
        {
            var result = new List<GraniteBlock>();
            foreach (var block in _blocks)
            {
                if (MassKg(block) > thresholdKg)
                {
                    result.Add(block);
                }
            }
            return result;
        }
    }
}
