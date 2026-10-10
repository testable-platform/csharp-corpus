using System;
using System.Collections.Generic;

namespace ArmoryOps
{
    public enum ClearanceLevelV45
    {
        VisitorV45,
        StaffV45,
        CommandV45
    }

    public class CheckpointV45
    {
        private string _checkpointIdFieldV45 = string.Empty;
        public string CheckpointIdV45 { get { return _checkpointIdFieldV45; } set { _checkpointIdFieldV45 = value; } }
        public ClearanceLevelV45 MinimumLevelV45 { get; set; }
    }

    public class BadgeV45
    {
        private string _holderNameFieldV45 = string.Empty;
        public string HolderNameV45 { get { return _holderNameFieldV45; } set { _holderNameFieldV45 = value; } }
        public ClearanceLevelV45 LevelV45 { get; set; }
        public bool RevokedV45 { get; set; }
    }

    public class CheckpointClearanceV45
    {
        private readonly Dictionary<string, CheckpointV45> _checkpointsV45 = new Dictionary<string, CheckpointV45>();

        public void RegisterV45(CheckpointV45 checkpointV45)
        {
            _checkpointsV45[checkpointV45.CheckpointIdV45] = checkpointV45;
        }

        public bool CanPassV45(string checkpointIdV45, BadgeV45 badgeV45)
        {
            if (badgeV45.RevokedV45)
            {
                return false;
            }

            CheckpointV45 checkpointV45;
            if (!_checkpointsV45.TryGetValue(checkpointIdV45, out checkpointV45))
            {
                return false;
            }

            return badgeV45.LevelV45 >= checkpointV45.MinimumLevelV45;
        }

        public List<string> AccessibleCheckpointsV45(BadgeV45 badgeV45)
        {
            var accessibleV45 = new List<string>();
            if (badgeV45.RevokedV45)
            {
                return accessibleV45;
            }

            foreach (var pairV45 in _checkpointsV45)
            {
                if (badgeV45.LevelV45 >= pairV45.Value.MinimumLevelV45)
                {
                    accessibleV45.Add(pairV45.Key);
                }
            }
            return accessibleV45;
        }

        public int CountByLevelV45(ClearanceLevelV45 levelV45)
        {
            int countV45 = 0;
            foreach (var checkpointV45 in _checkpointsV45.Values)
            {
                if (checkpointV45.MinimumLevelV45 == levelV45)
                {
                    countV45++;
                }
            }
            return countV45;
        }
    }
}
