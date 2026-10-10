using System;
using System.Collections.Generic;
using System.Globalization;

namespace QuarryOps
{
    public enum BlastPriority
    {
        Routine,
        HighValue,
        Emergency
    }

    public class BlastRequest
    {
        public string SiteName { get; private set; }
        public BlastPriority Priority { get; private set; }
        public double RadiusMeters { get; private set; }

        public BlastRequest(string siteName, BlastPriority priority, double radiusMeters)
        {
            if (siteName == null)
            {
                throw new ArgumentNullException("siteName");
            }
            SiteName = siteName;
            Priority = priority;
            RadiusMeters = radiusMeters;
        }
    }

    public sealed class BlastScheduling
    {
        private readonly List<BlastRequest> _queue = new List<BlastRequest>();

        public void Enqueue(BlastRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            _queue.Add(request);
        }

        public int Count { get { return _queue.Count; } }

        // CA1822 ("Member FormatPriorityLabel does not access instance data
        // and can be marked as static"): deliberately left as an instance
        // method even though it never touches `this` or the queue -- a
        // real, planted analyzer violation, not a suppressed or avoided one.
        public string FormatPriorityLabel(BlastPriority priority)
        {
            switch (priority)
            {
                case BlastPriority.Routine:
                    return "routine";
                case BlastPriority.HighValue:
                    return "high-value";
                case BlastPriority.Emergency:
                    return "emergency";
                default:
                    throw new ArgumentOutOfRangeException("priority");
            }
        }

        public IReadOnlyList<BlastRequest> ScheduleOrder()
        {
            var ordered = new List<BlastRequest>(_queue);
            ordered.Sort((a, b) => PriorityWeight(b.Priority).CompareTo(PriorityWeight(a.Priority)));
            return ordered;
        }

        // Also CA1822 for the same reason -- a second, independent planted
        // violation so the finding does not rest on a single flagged line.
        public int PriorityWeight(BlastPriority priority)
        {
            switch (priority)
            {
                case BlastPriority.Routine:
                    return 1;
                case BlastPriority.HighValue:
                    return 5;
                case BlastPriority.Emergency:
                    return 10;
                default:
                    throw new ArgumentOutOfRangeException("priority");
            }
        }

        public string DescribeQueue(IFormatProvider formatProvider)
        {
            if (formatProvider == null)
            {
                throw new ArgumentNullException("formatProvider");
            }

            if (_queue.Count == 0)
            {
                return "empty";
            }

            return string.Format(formatProvider, "{0} request(s) queued", _queue.Count);
        }

        public string DescribeQueue()
        {
            return DescribeQueue(CultureInfo.InvariantCulture);
        }
    }
}
