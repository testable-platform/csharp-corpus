using System;
using System.Collections.Generic;

namespace TextileMillOps
{
    public class LoomShiftV45
    {
        private string _loomIdFieldV45 = string.Empty;
        public string LoomIdV45 { get { return _loomIdFieldV45; } set { _loomIdFieldV45 = value; } }
        public int MetersWovenV45 { get; set; }
    }

    public class LoomCountV45
    {
        private readonly List<LoomShiftV45> _shiftsV45 = new List<LoomShiftV45>();

        public void LogShiftV45(LoomShiftV45 shiftV45)
        {
            _shiftsV45.Add(shiftV45);
        }

        public int TotalMetersWovenV45()
        {
            int totalV45 = 0;
            foreach (var shiftV45 in _shiftsV45)
            {
                totalV45 += shiftV45.MetersWovenV45;
            }
            return totalV45;
        }

        public int Count() { return _shiftsV45.Count; }
    }
}
