using System;
using System.Collections.Generic;

namespace CitrusGroveOps
{
    public class IrrigationZoneV9
    {
        public string ZoneIdV9 { get; set; } = string.Empty;
        public double LitersPerHourV9 { get; set; }
    }

    public class GroveIrrigationV9
    {
        private readonly List<IrrigationZoneV9> _zonesV9 = new List<IrrigationZoneV9>();

        public void RegisterV9(IrrigationZoneV9 zoneV9)
        {
            _zonesV9.Add(zoneV9);
        }

        public double TotalFlowLitersPerHourV9()
        {
            double totalV9 = 0;
            foreach (var zoneV9 in _zonesV9)
            {
                totalV9 += zoneV9.LitersPerHourV9;
            }
            return totalV9;
        }

        public int Count() => _zonesV9.Count;
    }
}
