using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    delegate void DelCalculate(int i, int j);
    
    class Calculator
    {
        public DelCalculate sender = null;
        public void subtract(int a, int b)
        {
            Console.WriteLine("The subtraction of calculated " + (a - b));
            int res = a + b;
            sender(res, a);
        }
        public void division(int a, int b)
        {
            Console.WriteLine("The division of calculated " + (a / b));
            int res = a - b;
            sender(res, a);
        }

        public void Modululo(int a, int b)
        {
            Console.WriteLine("The modulus of calculated " + (a % b));
        }

        public void multiply(int a, int b)
        {
            Console.WriteLine("The multiply of calculated " + (a * b));
        }

        public void add(int a, int b)
        {
            Console.WriteLine("The add of calculated " + (a+b));
        }
    }
    

    
}
