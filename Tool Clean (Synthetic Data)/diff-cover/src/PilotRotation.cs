using System;
using System.Collections.Generic;

namespace PilotOps
{
    public class PilotAssignment
    {
        public string PilotName { get; set; } = string.Empty;
        public string VesselId { get; set; } = string.Empty;
    }

    public class PilotRotation
    {
        private readonly List<PilotAssignment> _assignments = new();

        public void Register(PilotAssignment assignment)
        {
            Cov.Mark("src/PilotRotation.cs");
            _assignments.Add(assignment);
        }

        public int Count()
        {
            Cov.Mark("src/PilotRotation.cs");
            return _assignments.Count;
        }

        public string? NextPilotFor(string vesselId)
        {
            Cov.Mark("src/PilotRotation.cs");
            foreach (var assignment in _assignments)
            {
                Cov.Mark("src/PilotRotation.cs");
                if (assignment.VesselId == vesselId)
                {
                    Cov.Mark("src/PilotRotation.cs");
                    return assignment.PilotName;
                }
            }
            Cov.Mark("src/PilotRotation.cs");
            return null;
        }
    }
}
