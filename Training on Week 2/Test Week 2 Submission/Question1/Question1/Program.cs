using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            LandCalculator land = new LandCalculator();
            land.printCostForSqFeet();
            
            Console.WriteLine("Enter length");
            int length = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter breadth");
            int breadth = Int32.Parse(Console.ReadLine());



            land.PrintFinalCost();

            Console.ReadLine();
        }
    }
}
