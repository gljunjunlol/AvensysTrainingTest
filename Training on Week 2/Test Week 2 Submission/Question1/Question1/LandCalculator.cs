using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class LandCalculator : Rectangle
    {
        public int costForSqFeet;
        public int FinalCost;

        public void enterCost(int sqfeet, int finalcost)
        {
            costForSqFeet = sqfeet;
            FinalCost = finalcost;
        }
        public void printCostForSqFeet()
        {
            Console.WriteLine("Enter cost for square feet");
            int costForSqFeet = Int32.Parse(Console.ReadLine());
            Console.WriteLine("The cost of sq feet is:" + costForSqFeet);
        }

        public void PrintFinalCost()
        {
            Console.WriteLine("Total Final cost is " + string.Join(" ", (length * breadth * costForSqFeet)));
        }

        
    }

    
}
