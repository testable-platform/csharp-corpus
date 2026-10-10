using System;
using System.Collections.Generic;

namespace ArmoryOps
{
    public enum ClearanceLevelV9
    {
        VisitorV9,
        StaffV9,
        CommandV9
    }

    public class CheckpointV9
    {
        public string CheckpointIdV9 { get; set; } = string.Empty;
        public ClearanceLevelV9 MinimumLevelV9 { get; set; }
    }

    public class BadgeV9
    {
        public string HolderNameV9 { get; set; } = string.Empty;
        public ClearanceLevelV9 LevelV9 { get; set; }
        public bool RevokedV9 { get; set; }
    }

    public class CheckpointClearanceV9
    {
        private readonly Dictionary<string, CheckpointV9> _checkpointsV9 = new Dictionary<string, CheckpointV9>();

        public void RegisterV9(CheckpointV9 checkpointV9)
        {
            _checkpointsV9[checkpointV9.CheckpointIdV9] = checkpointV9;
        }

        public bool CanPassV9(string checkpointIdV9, BadgeV9 badgeV9)
        {
            if (badgeV9.RevokedV9)
            {
                return false;
            }

            CheckpointV9 checkpointV9;
            if (!_checkpointsV9.TryGetValue(checkpointIdV9, out checkpointV9))
            {
                return false;
            }

            return badgeV9.LevelV9 >= checkpointV9.MinimumLevelV9;
        }

        public List<string> AccessibleCheckpointsV9(BadgeV9 badgeV9)
        {
            var accessibleV9 = new List<string>();
            if (badgeV9.RevokedV9)
            {
                return accessibleV9;
            }

            foreach (var pairV9 in _checkpointsV9)
            {
                if (badgeV9.LevelV9 >= pairV9.Value.MinimumLevelV9)
                {
                    accessibleV9.Add(pairV9.Key);
                }
            }
            return accessibleV9;
        }

        public int CountByLevelV9(ClearanceLevelV9 levelV9)
        {
            int countV9 = 0;
            foreach (var checkpointV9 in _checkpointsV9.Values)
            {
                if (checkpointV9.MinimumLevelV9 == levelV9)
                {
                    countV9++;
                }
            }
            return countV9;
        }
    }
}
