using System;

namespace TeaPlantationOps
{
    public class HarvestGradingV9
    {
        public string GradeForV9(double leafMoisturePercentV9, int brokenLeafCountV9)
        {
            if (leafMoisturePercentV9 < 0 || leafMoisturePercentV9 > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(leafMoisturePercentV9));
            }

            if (leafMoisturePercentV9 <= 5 && brokenLeafCountV9 == 0)
            {
                return "Premium";
            }
            if (leafMoisturePercentV9 <= 10 && brokenLeafCountV9 <= 5)
            {
                return "Standard";
            }
            return "Utility";
        }
    }
}
