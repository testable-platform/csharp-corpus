using System;
using System.Collections.Generic;
using System.Globalization;

namespace ObservatoryOps
{
    public enum ObservationPriority
    {
        Routine,
        HighValue,
        TargetOfOpportunity
    }

    public class ObservationRequest
    {
        public string TargetName { get; }
        public ObservationPriority Priority { get; }
        public double MinimumAltitudeDegrees { get; }

        public ObservationRequest(string targetName, ObservationPriority priority, double minimumAltitudeDegrees)
        {
            if (targetName == null)
            {
                throw new ArgumentNullException(nameof(targetName));
            }
            TargetName = targetName;
            Priority = priority;
            MinimumAltitudeDegrees = minimumAltitudeDegrees;
        }
    }

    public sealed class TelescopeScheduling
    {
        private readonly List<ObservationRequest> _queue = new List<ObservationRequest>();

        public void Enqueue(ObservationRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            _queue.Add(request);
        }

        public int Count => _queue.Count;

        public static int PriorityWeight(ObservationPriority priority)
        {
            switch (priority)
            {
                case ObservationPriority.Routine:
                    return 1;
                case ObservationPriority.HighValue:
                    return 5;
                case ObservationPriority.TargetOfOpportunity:
                    return 10;
                default:
                    throw new ArgumentOutOfRangeException(nameof(priority));
            }
        }

        public IReadOnlyList<ObservationRequest> ScheduleOrder()
        {
            var ordered = new List<ObservationRequest>(_queue);
            ordered.Sort((a, b) => PriorityWeight(b.Priority).CompareTo(PriorityWeight(a.Priority)));
            return ordered;
        }

        public static bool IsObservable(ObservationRequest request, double currentAltitudeDegrees)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            return currentAltitudeDegrees >= request.MinimumAltitudeDegrees;
        }

        public string DescribeQueue(IFormatProvider formatProvider)
        {
            if (formatProvider == null)
            {
                throw new ArgumentNullException(nameof(formatProvider));
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
