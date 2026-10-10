using System;
using System.Collections.Generic;

namespace TextileMillOps
{
    public class LoomShiftV46
    {
        public string LoomIdV46 { get; set; } = string.Empty;
        public int MetersWovenV46 { get; set; }
    }

    public class LoomCountV46
    {
        private readonly List<LoomShiftV46> _shiftsV46 = new List<LoomShiftV46>();

        public void LogShiftV46(LoomShiftV46 shiftV46)
        {
            _shiftsV46.Add(shiftV46);
        }

        public int TotalMetersWovenV46()
        {
            int totalV46 = 0;
            foreach (var shiftV46 in _shiftsV46)
            {
                totalV46 += shiftV46.MetersWovenV46;
            }
            return totalV46;
        }

        public int Count() => _shiftsV46.Count;
    }
}
