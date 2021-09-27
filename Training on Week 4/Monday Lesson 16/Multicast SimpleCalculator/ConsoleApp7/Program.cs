using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    

    class Program
    {
        

        static void Main(string[] args)
        {

            simpleinterst_calc sc = new simpleinterst_calc();
            sc.sender += Receiver1;


            Sender2 dels2 = new Sender2(sc.GetPrinciple);       // multi cast here
            dels2 += sc.GetNoOfYears;
            dels2 += sc.GetInterest;
            dels2 += sc.Calculate;

            dels2();

            Console.ReadLine();

        }

        private static void Receiver1(double simpleinterest)
        {
            Console.WriteLine($"Simple interest: ${simpleinterest}");
        }

    }
}
