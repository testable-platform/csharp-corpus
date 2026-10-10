using System;
using System.Collections.Generic;

namespace SignalTowerOps
{
    public class DiagnosticPing
    {
        public string TowerId { get; set; } = string.Empty;
        public double LatencyMs { get; set; }
    }

    public class SignalTowerDiagnostics
    {
        private readonly List<DiagnosticPing> _pings = new List<DiagnosticPing>();

        public void Record(DiagnosticPing ping)
        {
            _pings.Add(ping);
        }

        public double AverageLatencyMs()
        {
            if (_pings.Count == 0)
            {
                return 0;
            }
            double total = 0;
            foreach (var ping in _pings)
            {
                total += ping.LatencyMs;
            }
            return total / _pings.Count;
        }
    }
}
