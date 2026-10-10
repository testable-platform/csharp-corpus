using System;
using System.Collections.Generic;

namespace SignalTowerOps
{
    public class DiagnosticPingV46
    {
        public string TowerIdV46 { get; set; } = string.Empty;
        public double LatencyMsV46 { get; set; }
    }

    public class SignalTowerDiagnosticsV46
    {
        private readonly List<DiagnosticPingV46> _pingsV46 = new List<DiagnosticPingV46>();

        public void RecordV46(DiagnosticPingV46 pingV46)
        {
            _pingsV46.Add(pingV46);
        }

        public double AverageLatencyMsV46()
        {
            if (_pingsV46.Count == 0)
            {
                return 0;
            }
            double totalV46 = 0;
            foreach (var pingV46 in _pingsV46)
            {
                totalV46 += pingV46.LatencyMsV46;
            }
            return totalV46 / _pingsV46.Count;
        }
    }
}
