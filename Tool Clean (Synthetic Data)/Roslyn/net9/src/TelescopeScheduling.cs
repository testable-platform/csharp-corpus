using System;
using System.Collections.Generic;
using System.Globalization;

namespace ObservatoryOps
{
    public enum ObservationPriorityV9
    {
        RoutineV9,
        HighValueV9,
        TargetOfOpportunityV9
    }

    public class ObservationRequestV9
    {
        public string TargetNameV9 { get; }
        public ObservationPriorityV9 PriorityV9 { get; }
        public double MinimumAltitudeDegreesV9 { get; }

        public ObservationRequestV9(string targetNameV9, ObservationPriorityV9 priorityV9, double minimumAltitudeDegreesV9)
        {
            if (targetNameV9 == null)
            {
                throw new ArgumentNullException(nameof(targetNameV9));
            }
            TargetNameV9 = targetNameV9;
            PriorityV9 = priorityV9;
            MinimumAltitudeDegreesV9 = minimumAltitudeDegreesV9;
        }
    }

    public sealed class TelescopeSchedulingV9
    {
        private readonly List<ObservationRequestV9> _queueV9 = new List<ObservationRequestV9>();

        public void EnqueueV9(ObservationRequestV9 requestV9)
        {
            if (requestV9 == null)
            {
                throw new ArgumentNullException(nameof(requestV9));
            }
            _queueV9.Add(requestV9);
        }

        public int Count => _queueV9.Count;

        public static int PriorityWeightV9(ObservationPriorityV9 priorityV9)
        {
            switch (priorityV9)
            {
                case ObservationPriorityV9.RoutineV9:
                    return 1;
                case ObservationPriorityV9.HighValueV9:
                    return 5;
                case ObservationPriorityV9.TargetOfOpportunityV9:
                    return 10;
                default:
                    throw new ArgumentOutOfRangeException(nameof(priorityV9));
            }
        }

        public IReadOnlyList<ObservationRequestV9> ScheduleOrderV9()
        {
            var orderedV9 = new List<ObservationRequestV9>(_queueV9);
            orderedV9.Sort((aV9, bV9) => PriorityWeightV9(bV9.PriorityV9).CompareTo(PriorityWeightV9(aV9.PriorityV9)));
            return orderedV9;
        }

        public static bool IsObservableV9(ObservationRequestV9 requestV9, double currentAltitudeDegreesV9)
        {
            if (requestV9 == null)
            {
                throw new ArgumentNullException(nameof(requestV9));
            }
            return currentAltitudeDegreesV9 >= requestV9.MinimumAltitudeDegreesV9;
        }

        public string DescribeQueueV9(IFormatProvider formatProviderV9)
        {
            if (formatProviderV9 == null)
            {
                throw new ArgumentNullException(nameof(formatProviderV9));
            }

            if (_queueV9.Count == 0)
            {
                return "empty";
            }

            return string.Format(formatProviderV9, "{0} request(s) queued", _queueV9.Count);
        }

        public string DescribeQueueV9()
        {
            return DescribeQueueV9(CultureInfo.InvariantCulture);
        }
    }
}
