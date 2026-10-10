using System;

namespace TeaPlantationOps
{
    public class HarvestGradingV30
    {
        public string GradeForV30(double leafMoisturePercentV30, int brokenLeafCountV30)
        {
            if (leafMoisturePercentV30 < 0 || leafMoisturePercentV30 > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(leafMoisturePercentV30));
            }

            if (leafMoisturePercentV30 <= 5 && brokenLeafCountV30 == 0)
            {
                return "Premium";
            }
            if (leafMoisturePercentV30 <= 10 && brokenLeafCountV30 <= 5)
            {
                return "Standard";
            }
            return "Utility";
        }
    }
}
