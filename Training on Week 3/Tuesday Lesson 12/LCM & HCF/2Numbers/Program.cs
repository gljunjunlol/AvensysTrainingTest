using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number here: ");
            int val1 = Int32.Parse(Console.ReadLine());
            Console.Write("Enter second number here: ");
            int val2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            int n1, n2, x;
            int LCM, HCF;

            n1 = val1;
            n2 = val2;
            while (n2 != 0)
            {
                x = n2;
                n2 = n1 % n2;    // check if can be divided
                n1 = x;
            }

            HCF = n1;
            LCM = (val1 * val2) / HCF;

            Console.WriteLine("LCM of values " + val1 + " & " + val2 + " is " + LCM);
            Console.WriteLine("GCF of values  " + val1 + " & " + val2 + " is " + HCF);
            Console.ReadLine();
        }
    }
}
