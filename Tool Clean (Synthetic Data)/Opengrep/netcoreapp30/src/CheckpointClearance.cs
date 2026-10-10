using System;
using System.Collections.Generic;

namespace ArmoryOps
{
    public enum ClearanceLevelV30
    {
        VisitorV30,
        StaffV30,
        CommandV30
    }

    public class CheckpointV30
    {
        public string CheckpointIdV30 { get; set; } = string.Empty;
        public ClearanceLevelV30 MinimumLevelV30 { get; set; }
    }

    public class BadgeV30
    {
        public string HolderNameV30 { get; set; } = string.Empty;
        public ClearanceLevelV30 LevelV30 { get; set; }
        public bool RevokedV30 { get; set; }
    }

    public class CheckpointClearanceV30
    {
        private readonly Dictionary<string, CheckpointV30> _checkpointsV30 = new Dictionary<string, CheckpointV30>();

        public void RegisterV30(CheckpointV30 checkpointV30)
        {
            _checkpointsV30[checkpointV30.CheckpointIdV30] = checkpointV30;
        }

        public bool CanPassV30(string checkpointIdV30, BadgeV30 badgeV30)
        {
            if (badgeV30.RevokedV30)
            {
                return false;
            }

            CheckpointV30 checkpointV30;
            if (!_checkpointsV30.TryGetValue(checkpointIdV30, out checkpointV30))
            {
                return false;
            }

            return badgeV30.LevelV30 >= checkpointV30.MinimumLevelV30;
        }

        public List<string> AccessibleCheckpointsV30(BadgeV30 badgeV30)
        {
            var accessibleV30 = new List<string>();
            if (badgeV30.RevokedV30)
            {
                return accessibleV30;
            }

            foreach (var pairV30 in _checkpointsV30)
            {
                if (badgeV30.LevelV30 >= pairV30.Value.MinimumLevelV30)
                {
                    accessibleV30.Add(pairV30.Key);
                }
            }
            return accessibleV30;
        }

        public int CountByLevelV30(ClearanceLevelV30 levelV30)
        {
            int countV30 = 0;
            foreach (var checkpointV30 in _checkpointsV30.Values)
            {
                if (checkpointV30.MinimumLevelV30 == levelV30)
                {
                    countV30++;
                }
            }
            return countV30;
        }
    }
}
