using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class IrrigationZone
    {
        private string _zoneIdField = string.Empty;
        public string ZoneId { get { return _zoneIdField; } set { _zoneIdField = value; } }
        public double LitersPerHour { get; set; }
    }

    public class GroveIrrigationZones
    {
        private readonly List<IrrigationZone> _zones = new List<IrrigationZone>();

        public void AddZone(IrrigationZone zone)
        {
            _zones.Add(zone);
        }

        public int Count()
        {
            return _zones.Count;
        }

        public double TotalFlowRate()
        {
            double total = 0;
            foreach (var zone in _zones)
            {
                total += zone.LitersPerHour;
            }
            return total;
        }
    }
}
