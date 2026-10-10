using System;
using System.Collections.Generic;

namespace CitrusGroveOps
{
    public class IrrigationZoneV30
    {
        public string ZoneIdV30 { get; set; } = string.Empty;
        public double LitersPerHourV30 { get; set; }
    }

    public class GroveIrrigationV30
    {
        private readonly List<IrrigationZoneV30> _zonesV30 = new List<IrrigationZoneV30>();

        public void RegisterV30(IrrigationZoneV30 zoneV30)
        {
            _zonesV30.Add(zoneV30);
        }

        public double TotalFlowLitersPerHourV30()
        {
            double totalV30 = 0;
            foreach (var zoneV30 in _zonesV30)
            {
                totalV30 += zoneV30.LitersPerHourV30;
            }
            return totalV30;
        }

        public int Count() => _zonesV30.Count;
    }
}
