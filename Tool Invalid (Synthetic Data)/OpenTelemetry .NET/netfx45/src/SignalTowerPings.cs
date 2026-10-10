using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class SignalPing
    {
        private string _towerIdField = string.Empty;
        public string TowerId { get { return _towerIdField; } set { _towerIdField = value; } }
        public int SignalStrength { get; set; }
    }

    public class SignalTowerPings
    {
        private readonly List<SignalPing> _pings = new List<SignalPing>();

        public void Record(SignalPing ping)
        {
            _pings.Add(ping);
        }

        public int Count()
        {
            return _pings.Count;
        }

        public double AverageStrength()
        {
            if (_pings.Count == 0)
            {
                return 0;
            }
            double total = 0;
            foreach (var ping in _pings)
            {
                total += ping.SignalStrength;
            }
            return total / _pings.Count;
        }
    }
}
