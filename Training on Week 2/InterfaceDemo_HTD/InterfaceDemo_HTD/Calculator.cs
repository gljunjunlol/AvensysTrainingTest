using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo_HTD
{
    // class Calculator: IAdd, ISubtract, ICalculator : Multiple interface implementation
    //class Calculator : ICalculator                   //Icaculator inherit from iadd interface and isubtract interface
    class Calculator : IAdd, IAddDuplicate
    {


        public int division(int a, int b)
        {
            return a / b;
        }

        public int Modululo(int a, int b)
        {
            return a % b;
        }

        public int multiply(int a, int b)
        {
            return a * b;
        }
         
        public int subtract(int a, int b)
        {
            return a -b;
        }
        public int bitwiseAnd(int a, int b)
        {
            return a & b;
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
        int IAdd.Add(int a, int b)
        {
            Console.WriteLine("in Iadd method");
            return a + b;
        }
        int IAddDuplicate.Add(int a, int b)
        {
            Console.WriteLine("in IAddDuplicate method");
            return a + b;
        }
    }
}
