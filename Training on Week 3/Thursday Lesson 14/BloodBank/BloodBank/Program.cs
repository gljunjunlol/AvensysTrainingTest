using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank
{
    class Program
    {
        static void Main(string[] args)
        {
            DifferentBloodGroup pub = new DifferentBloodGroup();
            pub.UnitsOfBloodCalculationCompleted += Pub_UnitsOfBloodCalculationCompleted;

            pub.BloodBankUnits(40, 50, 60, 70);
            Console.ReadLine();
        }

        private static void Pub_UnitsOfBloodCalculationCompleted(int a, int b, int c, int d)
        {
            Console.WriteLine("Hello");
        }
    }
}
