using System;

namespace Coastal.Lighthouse
{
    /// <summary>
    /// Inverse-corpus counterpart to the clean fixture's LighthouseKeeperLog:
    /// engineered so unilyze reports a genuinely, measurably wrong
    /// (majority-complex) result. 3 of 4 methods are deliberately over
    /// threshold; IsOperational is the negative control proving the scan
    /// reads the file rather than flagging everything indiscriminately.
    /// </summary>
    public sealed class BeaconRotationScheduler
    {
        // Deliberately over HighComplexity (CycCC >= 15): a flat routing
        // switch with 16 arms instead of a lookup table.
        public string ClassifyBeaconPattern(int patternCode)
        {
            switch (patternCode)
            {
                case 1: return "FixedWhite";
                case 2: return "FixedRed";
                case 3: return "FixedGreen";
                case 4: return "FlashingWhite";
                case 5: return "FlashingRed";
                case 6: return "FlashingGreen";
                case 7: return "OccultingWhite";
                case 8: return "OccultingRed";
                case 9: return "IsophaseWhite";
                case 10: return "GroupFlash2";
                case 11: return "GroupFlash3";
                case 12: return "GroupFlash4";
                case 13: return "MorseCodeU";
                case 14: return "MorseCodeA";
                case 15: return "AlternatingWhiteRed";
                case 16: return "AlternatingWhiteGreen";
                default: return "Unknown";
            }
        }

        // Deliberately over HighComplexity (CogCC >= 15): a chained,
        // deeply nested condition ladder instead of a decision table.
        public string DetermineFogHornSchedule(int visibilityMeters, bool stormWarning, bool nightfall, int vesselTraffic)
        {
            if (stormWarning)
            {
                if (visibilityMeters < 200)
                {
                    if (vesselTraffic > 10)
                    {
                        if (nightfall)
                        {
                            return "ContinuousBlast";
                        }
                        else
                        {
                            return "TripleBlastEvery30s";
                        }
                    }
                    else
                    {
                        if (nightfall)
                        {
                            return "DoubleBlastEvery45s";
                        }
                        else
                        {
                            return "SingleBlastEvery60s";
                        }
                    }
                }
                else
                {
                    if (vesselTraffic > 10)
                    {
                        return "SingleBlastEvery90s";
                    }
                    else
                    {
                        return "AdvisoryOnly";
                    }
                }
            }
            else
            {
                if (visibilityMeters < 500)
                {
                    if (nightfall)
                    {
                        return "SingleBlastEvery120s";
                    }
                    else
                    {
                        return "AdvisoryOnly";
                    }
                }
                else
                {
                    return "Silent";
                }
            }
        }

        // Deliberately over ExcessiveParameters (> 5).
        public string BuildMaintenanceReport(string keeperName, DateTime inspectionDate, int lampHours, bool lensCleaned, bool mechanismOiled, bool batteryTested, string notes)
        {
            return $"{inspectionDate:u} by {keeperName}: lampHours={lampHours}, lensCleaned={lensCleaned}, mechanismOiled={mechanismOiled}, batteryTested={batteryTested}, notes={notes}";
        }

        // Negative control, left clean: proves the scan is reading the
        // file rather than flagging everything indiscriminately.
        public bool IsOperational(bool powerConnected)
        {
            return powerConnected;
        }
    }
}
