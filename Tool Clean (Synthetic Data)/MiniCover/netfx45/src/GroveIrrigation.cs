using System;
using System.Collections.Generic;

namespace CitrusGroveOps
{
    public class IrrigationZoneV45
    {
        private string _zoneIdFieldV45 = string.Empty;
        public string ZoneIdV45 { get { return _zoneIdFieldV45; } set { _zoneIdFieldV45 = value; } }
        public double LitersPerHourV45 { get; set; }
    }

    public class GroveIrrigationV45
    {
        private readonly List<IrrigationZoneV45> _zonesV45 = new List<IrrigationZoneV45>();

        public void RegisterV45(IrrigationZoneV45 zoneV45)
        {
            _zonesV45.Add(zoneV45);
        }

        public double TotalFlowLitersPerHourV45()
        {
            double totalV45 = 0;
            foreach (var zoneV45 in _zonesV45)
            {
                totalV45 += zoneV45.LitersPerHourV45;
            }
            return totalV45;
        }

        public int Count() { return _zonesV45.Count; }
    }
}
