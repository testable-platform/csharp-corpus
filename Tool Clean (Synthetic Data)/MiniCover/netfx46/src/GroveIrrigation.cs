using System;
using System.Collections.Generic;

namespace CitrusGroveOps
{
    public class IrrigationZoneV46
    {
        public string ZoneIdV46 { get; set; } = string.Empty;
        public double LitersPerHourV46 { get; set; }
    }

    public class GroveIrrigationV46
    {
        private readonly List<IrrigationZoneV46> _zonesV46 = new List<IrrigationZoneV46>();

        public void RegisterV46(IrrigationZoneV46 zoneV46)
        {
            _zonesV46.Add(zoneV46);
        }

        public double TotalFlowLitersPerHourV46()
        {
            double totalV46 = 0;
            foreach (var zoneV46 in _zonesV46)
            {
                totalV46 += zoneV46.LitersPerHourV46;
            }
            return totalV46;
        }

        public int Count() => _zonesV46.Count;
    }
}
