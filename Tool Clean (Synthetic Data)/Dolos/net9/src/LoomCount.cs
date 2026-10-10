using System;
using System.Collections.Generic;

namespace TextileMillOps
{
    public class LoomShiftV9
    {
        public string LoomIdV9 { get; set; } = string.Empty;
        public int MetersWovenV9 { get; set; }
    }

    public class LoomCountV9
    {
        private readonly List<LoomShiftV9> _shiftsV9 = new List<LoomShiftV9>();

        public void LogShiftV9(LoomShiftV9 shiftV9)
        {
            _shiftsV9.Add(shiftV9);
        }

        public int TotalMetersWovenV9()
        {
            int totalV9 = 0;
            foreach (var shiftV9 in _shiftsV9)
            {
                totalV9 += shiftV9.MetersWovenV9;
            }
            return totalV9;
        }

        public int Count() => _shiftsV9.Count;
    }
}
