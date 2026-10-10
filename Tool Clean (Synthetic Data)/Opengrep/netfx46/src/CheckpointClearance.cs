using System;
using System.Collections.Generic;

namespace ArmoryOps
{
    public enum ClearanceLevelV46
    {
        VisitorV46,
        StaffV46,
        CommandV46
    }

    public class CheckpointV46
    {
        public string CheckpointIdV46 { get; set; } = string.Empty;
        public ClearanceLevelV46 MinimumLevelV46 { get; set; }
    }

    public class BadgeV46
    {
        public string HolderNameV46 { get; set; } = string.Empty;
        public ClearanceLevelV46 LevelV46 { get; set; }
        public bool RevokedV46 { get; set; }
    }

    public class CheckpointClearanceV46
    {
        private readonly Dictionary<string, CheckpointV46> _checkpointsV46 = new Dictionary<string, CheckpointV46>();

        public void RegisterV46(CheckpointV46 checkpointV46)
        {
            _checkpointsV46[checkpointV46.CheckpointIdV46] = checkpointV46;
        }

        public bool CanPassV46(string checkpointIdV46, BadgeV46 badgeV46)
        {
            if (badgeV46.RevokedV46)
            {
                return false;
            }

            CheckpointV46 checkpointV46;
            if (!_checkpointsV46.TryGetValue(checkpointIdV46, out checkpointV46))
            {
                return false;
            }

            return badgeV46.LevelV46 >= checkpointV46.MinimumLevelV46;
        }

        public List<string> AccessibleCheckpointsV46(BadgeV46 badgeV46)
        {
            var accessibleV46 = new List<string>();
            if (badgeV46.RevokedV46)
            {
                return accessibleV46;
            }

            foreach (var pairV46 in _checkpointsV46)
            {
                if (badgeV46.LevelV46 >= pairV46.Value.MinimumLevelV46)
                {
                    accessibleV46.Add(pairV46.Key);
                }
            }
            return accessibleV46;
        }

        public int CountByLevelV46(ClearanceLevelV46 levelV46)
        {
            int countV46 = 0;
            foreach (var checkpointV46 in _checkpointsV46.Values)
            {
                if (checkpointV46.MinimumLevelV46 == levelV46)
                {
                    countV46++;
                }
            }
            return countV46;
        }
    }
}
