using System;
using System.Collections.Generic;
using System.Globalization;

namespace ObservatoryOps
{
    public enum ObservationPriorityV30
    {
        RoutineV30,
        HighValueV30,
        TargetOfOpportunityV30
    }

    public class ObservationRequestV30
    {
        public string TargetNameV30 { get; }
        public ObservationPriorityV30 PriorityV30 { get; }
        public double MinimumAltitudeDegreesV30 { get; }

        public ObservationRequestV30(string targetNameV30, ObservationPriorityV30 priorityV30, double minimumAltitudeDegreesV30)
        {
            if (targetNameV30 == null)
            {
                throw new ArgumentNullException(nameof(targetNameV30));
            }
            TargetNameV30 = targetNameV30;
            PriorityV30 = priorityV30;
            MinimumAltitudeDegreesV30 = minimumAltitudeDegreesV30;
        }
    }

    public sealed class TelescopeSchedulingV30
    {
        private readonly List<ObservationRequestV30> _queueV30 = new List<ObservationRequestV30>();

        public void EnqueueV30(ObservationRequestV30 requestV30)
        {
            if (requestV30 == null)
            {
                throw new ArgumentNullException(nameof(requestV30));
            }
            _queueV30.Add(requestV30);
        }

        public int Count => _queueV30.Count;

        public static int PriorityWeightV30(ObservationPriorityV30 priorityV30)
        {
            switch (priorityV30)
            {
                case ObservationPriorityV30.RoutineV30:
                    return 1;
                case ObservationPriorityV30.HighValueV30:
                    return 5;
                case ObservationPriorityV30.TargetOfOpportunityV30:
                    return 10;
                default:
                    throw new ArgumentOutOfRangeException(nameof(priorityV30));
            }
        }

        public IReadOnlyList<ObservationRequestV30> ScheduleOrderV30()
        {
            var orderedV30 = new List<ObservationRequestV30>(_queueV30);
            orderedV30.Sort((aV30, bV30) => PriorityWeightV30(bV30.PriorityV30).CompareTo(PriorityWeightV30(aV30.PriorityV30)));
            return orderedV30;
        }

        public static bool IsObservableV30(ObservationRequestV30 requestV30, double currentAltitudeDegreesV30)
        {
            if (requestV30 == null)
            {
                throw new ArgumentNullException(nameof(requestV30));
            }
            return currentAltitudeDegreesV30 >= requestV30.MinimumAltitudeDegreesV30;
        }

        public string DescribeQueueV30(IFormatProvider formatProviderV30)
        {
            if (formatProviderV30 == null)
            {
                throw new ArgumentNullException(nameof(formatProviderV30));
            }

            if (_queueV30.Count == 0)
            {
                return "empty";
            }

            return string.Format(formatProviderV30, "{0} request(s) queued", _queueV30.Count);
        }

        public string DescribeQueueV30()
        {
            return DescribeQueueV30(CultureInfo.InvariantCulture);
        }
    }
}
