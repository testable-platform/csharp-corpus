using System;
using System.Collections.Generic;

namespace SignalTowerOps
{
    public class DiagnosticPingV9
    {
        public string TowerIdV9 { get; set; } = string.Empty;
        public double LatencyMsV9 { get; set; }
    }

    public class SignalTowerDiagnosticsV9
    {
        private readonly List<DiagnosticPingV9> _pingsV9 = new List<DiagnosticPingV9>();

        public void RecordV9(DiagnosticPingV9 pingV9)
        {
            _pingsV9.Add(pingV9);
        }

        public double AverageLatencyMsV9()
        {
            if (_pingsV9.Count == 0)
            {
                return 0;
            }
            double totalV9 = 0;
            foreach (var pingV9 in _pingsV9)
            {
                totalV9 += pingV9.LatencyMsV9;
            }
            return totalV9 / _pingsV9.Count;
        }
    }
}
