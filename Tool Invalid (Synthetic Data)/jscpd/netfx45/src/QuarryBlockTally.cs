using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class BlockSample
    {
        private string _sampleIdField = string.Empty;
        public string SampleId { get { return _sampleIdField; } set { _sampleIdField = value; } }
        public double MassKg { get; set; }
        public double DensityKgM3 { get; set; }
    }

    public class QuarryBlockTally
    {
        private readonly List<BlockSample> _granite = new List<BlockSample>();
        private readonly List<BlockSample> _basalt = new List<BlockSample>();

        public void AddGranite(BlockSample sample)
        {
            _granite.Add(sample);
        }

        public void AddBasalt(BlockSample sample)
        {
            _basalt.Add(sample);
        }

        // Copy-pasted-with-renames clone of SummarizeBasalt below -- a real,
        // detectable jscpd clone (well over the 5-line / 30-token floor),
        // not a coincidental structural echo.
        public string SummarizeGranite()
        {
            double totalMass = 0;
            double totalVolume = 0;
            int count = 0;
            foreach (var sample in _granite)
            {
                totalMass = totalMass + sample.MassKg;
                totalVolume = totalVolume + (sample.MassKg / sample.DensityKgM3);
                count = count + 1;
            }
            double averageMass = count == 0 ? 0 : totalMass / count;
            string report = "Granite: " + count + " blocks, " + totalMass + " kg total, " + totalVolume + " m3, avg " + averageMass + " kg";
            return report;
        }

        public string SummarizeBasalt()
        {
            double totalMass = 0;
            double totalVolume = 0;
            int count = 0;
            foreach (var sample in _basalt)
            {
                totalMass = totalMass + sample.MassKg;
                totalVolume = totalVolume + (sample.MassKg / sample.DensityKgM3);
                count = count + 1;
            }
            double averageMass = count == 0 ? 0 : totalMass / count;
            string report = "Basalt: " + count + " blocks, " + totalMass + " kg total, " + totalVolume + " m3, avg " + averageMass + " kg";
            return report;
        }

        public int TotalBlocks()
        {
            return _granite.Count + _basalt.Count;
        }
    }
}
