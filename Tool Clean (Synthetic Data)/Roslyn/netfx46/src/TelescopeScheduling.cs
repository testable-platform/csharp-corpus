using System;
using System.Collections.Generic;
using System.Globalization;

namespace ObservatoryOps
{
    public enum ObservationPriorityV46
    {
        RoutineV46,
        HighValueV46,
        TargetOfOpportunityV46
    }

    public class ObservationRequestV46
    {
        public string TargetNameV46 { get; }
        public ObservationPriorityV46 PriorityV46 { get; }
        public double MinimumAltitudeDegreesV46 { get; }

        public ObservationRequestV46(string targetNameV46, ObservationPriorityV46 priorityV46, double minimumAltitudeDegreesV46)
        {
            if (targetNameV46 == null)
            {
                throw new ArgumentNullException(nameof(targetNameV46));
            }
            TargetNameV46 = targetNameV46;
            PriorityV46 = priorityV46;
            MinimumAltitudeDegreesV46 = minimumAltitudeDegreesV46;
        }
    }

    public sealed class TelescopeSchedulingV46
    {
        private readonly List<ObservationRequestV46> _queueV46 = new List<ObservationRequestV46>();

        public void EnqueueV46(ObservationRequestV46 requestV46)
        {
            if (requestV46 == null)
            {
                throw new ArgumentNullException(nameof(requestV46));
            }
            _queueV46.Add(requestV46);
        }

        public int Count => _queueV46.Count;

        public static int PriorityWeightV46(ObservationPriorityV46 priorityV46)
        {
            switch (priorityV46)
            {
                case ObservationPriorityV46.RoutineV46:
                    return 1;
                case ObservationPriorityV46.HighValueV46:
                    return 5;
                case ObservationPriorityV46.TargetOfOpportunityV46:
                    return 10;
                default:
                    throw new ArgumentOutOfRangeException(nameof(priorityV46));
            }
        }

        public IReadOnlyList<ObservationRequestV46> ScheduleOrderV46()
        {
            var orderedV46 = new List<ObservationRequestV46>(_queueV46);
            orderedV46.Sort((aV46, bV46) => PriorityWeightV46(bV46.PriorityV46).CompareTo(PriorityWeightV46(aV46.PriorityV46)));
            return orderedV46;
        }

        public static bool IsObservableV46(ObservationRequestV46 requestV46, double currentAltitudeDegreesV46)
        {
            if (requestV46 == null)
            {
                throw new ArgumentNullException(nameof(requestV46));
            }
            return currentAltitudeDegreesV46 >= requestV46.MinimumAltitudeDegreesV46;
        }

        public string DescribeQueueV46(IFormatProvider formatProviderV46)
        {
            if (formatProviderV46 == null)
            {
                throw new ArgumentNullException(nameof(formatProviderV46));
            }

            if (_queueV46.Count == 0)
            {
                return "empty";
            }

            return string.Format(formatProviderV46, "{0} request(s) queued", _queueV46.Count);
        }

        public string DescribeQueueV46()
        {
            return DescribeQueueV46(CultureInfo.InvariantCulture);
        }
    }
}
