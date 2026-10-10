using System;
using System.Collections.Generic;

namespace CitrusGroveOps
{
    public class IrrigationZone
    {
        public string ZoneId { get; set; } = string.Empty;
        public double LitersPerHour { get; set; }
    }

    public class GroveIrrigation
    {
        private readonly List<IrrigationZone> _zones = new List<IrrigationZone>();

        public void Register(IrrigationZone zone)
        {
            _zones.Add(zone);
        }

        public double TotalFlowLitersPerHour()
        {
            double total = 0;
            foreach (var zone in _zones)
            {
                total += zone.LitersPerHour;
            }
            return total;
        }

        public int Count() => _zones.Count;
    }
}
