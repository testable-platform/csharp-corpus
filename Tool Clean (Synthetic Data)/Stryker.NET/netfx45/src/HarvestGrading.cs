using System;

namespace TeaPlantationOps
{
    public class HarvestGradingV45
    {
        public string GradeForV45(double leafMoisturePercentV45, int brokenLeafCountV45)
        {
            if (leafMoisturePercentV45 < 0 || leafMoisturePercentV45 > 100)
            {
                throw new ArgumentOutOfRangeException("leafMoisturePercent");
            }

            if (leafMoisturePercentV45 <= 5 && brokenLeafCountV45 == 0)
            {
                return "Premium";
            }
            if (leafMoisturePercentV45 <= 10 && brokenLeafCountV45 <= 5)
            {
                return "Standard";
            }
            return "Utility";
        }
    }
}
