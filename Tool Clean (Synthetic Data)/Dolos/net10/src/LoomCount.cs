using System;
using System.Collections.Generic;

namespace TextileMillOps
{
    public class LoomShift
    {
        public string LoomId { get; set; } = string.Empty;
        public int MetersWoven { get; set; }
    }

    public class LoomCount
    {
        private readonly List<LoomShift> _shifts = new List<LoomShift>();

        public void LogShift(LoomShift shift)
        {
            _shifts.Add(shift);
        }

        public int TotalMetersWoven()
        {
            int total = 0;
            foreach (var shift in _shifts)
            {
                total += shift.MetersWoven;
            }
            return total;
        }

        public int Count() => _shifts.Count;
    }
}
