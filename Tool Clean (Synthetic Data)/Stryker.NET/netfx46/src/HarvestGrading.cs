using System;

namespace TeaPlantationOps
{
    public class HarvestGradingV46
    {
        public string GradeForV46(double leafMoisturePercentV46, int brokenLeafCountV46)
        {
            if (leafMoisturePercentV46 < 0 || leafMoisturePercentV46 > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(leafMoisturePercentV46));
            }

            if (leafMoisturePercentV46 <= 5 && brokenLeafCountV46 == 0)
            {
                return "Premium";
            }
            if (leafMoisturePercentV46 <= 10 && brokenLeafCountV46 <= 5)
            {
                return "Standard";
            }
            return "Utility";
        }
    }
}
