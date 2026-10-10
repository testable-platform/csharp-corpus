using System;

namespace TeaPlantationOps
{
    public class HarvestGrading
    {
        public string GradeFor(double leafMoisturePercent, int brokenLeafCount)
        {
            if (leafMoisturePercent < 0 || leafMoisturePercent > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(leafMoisturePercent));
            }

            if (leafMoisturePercent <= 5 && brokenLeafCount == 0)
            {
                return "Premium";
            }
            if (leafMoisturePercent <= 10 && brokenLeafCount <= 5)
            {
                return "Standard";
            }
            return "Utility";
        }
    }
}
