using System;

namespace BusinessLogic.OrderLogic
{
    public class CrewDiscount
    {
        public double CalculateDiscount(int crewMembers)
        {
            double discountInPct = 2.5;
            double startupPct = 5;
            if (crewMembers <2)
            {
                return 0;
            }
            if (crewMembers > 9)
            {
                return 35;
            }
            
            return crewMembers*discountInPct+startupPct;

        }

        public decimal CalculatePrice(int crewMembers, decimal gamePrice)
        {
            decimal discountPct = (decimal) CalculateDiscount(crewMembers);

            decimal discountDecimal = gamePrice/100*discountPct;

            return gamePrice - discountDecimal;

        }
    }
}