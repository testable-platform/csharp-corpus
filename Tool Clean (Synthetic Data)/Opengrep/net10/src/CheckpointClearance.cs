using System;
using System.Collections.Generic;

namespace ArmoryOps
{
    public enum ClearanceLevel
    {
        Visitor,
        Staff,
        Command
    }

    public class Checkpoint
    {
        public string CheckpointId { get; set; } = string.Empty;
        public ClearanceLevel MinimumLevel { get; set; }
    }

    public class Badge
    {
        public string HolderName { get; set; } = string.Empty;
        public ClearanceLevel Level { get; set; }
        public bool Revoked { get; set; }
    }

    public class CheckpointClearance
    {
        private readonly Dictionary<string, Checkpoint> _checkpoints = new Dictionary<string, Checkpoint>();

        public void Register(Checkpoint checkpoint)
        {
            _checkpoints[checkpoint.CheckpointId] = checkpoint;
        }

        public bool CanPass(string checkpointId, Badge badge)
        {
            if (badge.Revoked)
            {
                return false;
            }

            Checkpoint checkpoint;
            if (!_checkpoints.TryGetValue(checkpointId, out checkpoint))
            {
                return false;
            }

            return badge.Level >= checkpoint.MinimumLevel;
        }

        public List<string> AccessibleCheckpoints(Badge badge)
        {
            var accessible = new List<string>();
            if (badge.Revoked)
            {
                return accessible;
            }

            foreach (var pair in _checkpoints)
            {
                if (badge.Level >= pair.Value.MinimumLevel)
                {
                    accessible.Add(pair.Key);
                }
            }
            return accessible;
        }

        public int CountByLevel(ClearanceLevel level)
        {
            int count = 0;
            foreach (var checkpoint in _checkpoints.Values)
            {
                if (checkpoint.MinimumLevel == level)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
