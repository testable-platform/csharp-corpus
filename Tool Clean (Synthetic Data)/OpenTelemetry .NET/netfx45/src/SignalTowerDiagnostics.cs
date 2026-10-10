using System;
using System.Collections.Generic;

namespace SignalTowerOps
{
    public class DiagnosticPingV45
    {
        private string _towerIdFieldV45 = string.Empty;
        public string TowerIdV45 { get { return _towerIdFieldV45; } set { _towerIdFieldV45 = value; } }
        public double LatencyMsV45 { get; set; }
    }

    public class SignalTowerDiagnosticsV45
    {
        private readonly List<DiagnosticPingV45> _pingsV45 = new List<DiagnosticPingV45>();

        public void RecordV45(DiagnosticPingV45 pingV45)
        {
            _pingsV45.Add(pingV45);
        }

        public double AverageLatencyMsV45()
        {
            if (_pingsV45.Count == 0)
            {
                return 0;
            }
            double totalV45 = 0;
            foreach (var pingV45 in _pingsV45)
            {
                totalV45 += pingV45.LatencyMsV45;
            }
            return totalV45 / _pingsV45.Count;
        }
    }
}
