using System;
using System.Collections.Generic;

namespace TextileMillOps
{
    public class LoomShiftV30
    {
        public string LoomIdV30 { get; set; } = string.Empty;
        public int MetersWovenV30 { get; set; }
    }

    public class LoomCountV30
    {
        private readonly List<LoomShiftV30> _shiftsV30 = new List<LoomShiftV30>();

        public void LogShiftV30(LoomShiftV30 shiftV30)
        {
            _shiftsV30.Add(shiftV30);
        }

        public int TotalMetersWovenV30()
        {
            int totalV30 = 0;
            foreach (var shiftV30 in _shiftsV30)
            {
                totalV30 += shiftV30.MetersWovenV30;
            }
            return totalV30;
        }

        public int Count() => _shiftsV30.Count;
    }
}
