using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Operation
    {
        public static void performOperation(int a, int b, DelCalculate del)
        {
            del(a, b);
            Console.WriteLine("Operation complete");

        }
    }
}
