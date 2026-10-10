using System;
using System.Collections.Generic;
using System.Globalization;

namespace ObservatoryOps
{
    public enum ObservationPriorityV45
    {
        RoutineV45,
        HighValueV45,
        TargetOfOpportunityV45
    }

    public class ObservationRequestV45
    {
        public string TargetNameV45 { get; private set; }
        public ObservationPriorityV45 PriorityV45 { get; private set; }
        public double MinimumAltitudeDegreesV45 { get; private set; }

        public ObservationRequestV45(string targetNameV45, ObservationPriorityV45 priorityV45, double minimumAltitudeDegreesV45)
        {
            if (targetNameV45 == null)
            {
                throw new ArgumentNullException("targetName");
            }
            TargetNameV45 = targetNameV45;
            PriorityV45 = priorityV45;
            MinimumAltitudeDegreesV45 = minimumAltitudeDegreesV45;
        }
    }

    public sealed class TelescopeSchedulingV45
    {
        private readonly List<ObservationRequestV45> _queueV45 = new List<ObservationRequestV45>();

        public void EnqueueV45(ObservationRequestV45 requestV45)
        {
            if (requestV45 == null)
            {
                throw new ArgumentNullException("request");
            }
            _queueV45.Add(requestV45);
        }

        public int Count { get { return _queueV45.Count; } }

        public static int PriorityWeightV45(ObservationPriorityV45 priorityV45)
        {
            switch (priorityV45)
            {
                case ObservationPriorityV45.RoutineV45:
                    return 1;
                case ObservationPriorityV45.HighValueV45:
                    return 5;
                case ObservationPriorityV45.TargetOfOpportunityV45:
                    return 10;
                default:
                    throw new ArgumentOutOfRangeException("priority");
            }
        }

        public IReadOnlyList<ObservationRequestV45> ScheduleOrderV45()
        {
            var orderedV45 = new List<ObservationRequestV45>(_queueV45);
            orderedV45.Sort((aV45, bV45) => PriorityWeightV45(bV45.PriorityV45).CompareTo(PriorityWeightV45(aV45.PriorityV45)));
            return orderedV45;
        }

        public static bool IsObservableV45(ObservationRequestV45 requestV45, double currentAltitudeDegreesV45)
        {
            if (requestV45 == null)
            {
                throw new ArgumentNullException("request");
            }
            return currentAltitudeDegreesV45 >= requestV45.MinimumAltitudeDegreesV45;
        }

        public string DescribeQueueV45(IFormatProvider formatProviderV45)
        {
            if (formatProviderV45 == null)
            {
                throw new ArgumentNullException("formatProvider");
            }

            if (_queueV45.Count == 0)
            {
                return "empty";
            }

            return string.Format(formatProviderV45, "{0} request(s) queued", _queueV45.Count);
        }

        public string DescribeQueueV45()
        {
            return DescribeQueueV45(CultureInfo.InvariantCulture);
        }
    }
}
