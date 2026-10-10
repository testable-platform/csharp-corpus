using System;
using System.Collections.Generic;

namespace SignalTowerOps
{
    public class DiagnosticPingV30
    {
        public string TowerIdV30 { get; set; } = string.Empty;
        public double LatencyMsV30 { get; set; }
    }

    public class SignalTowerDiagnosticsV30
    {
        private readonly List<DiagnosticPingV30> _pingsV30 = new List<DiagnosticPingV30>();

        public void RecordV30(DiagnosticPingV30 pingV30)
        {
            _pingsV30.Add(pingV30);
        }

        public double AverageLatencyMsV30()
        {
            if (_pingsV30.Count == 0)
            {
                return 0;
            }
            double totalV30 = 0;
            foreach (var pingV30 in _pingsV30)
            {
                totalV30 += pingV30.LatencyMsV30;
            }
            return totalV30 / _pingsV30.Count;
        }
    }
}
