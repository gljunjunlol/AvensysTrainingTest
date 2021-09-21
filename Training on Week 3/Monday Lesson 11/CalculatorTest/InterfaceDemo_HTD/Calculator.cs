using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo_HTD
{
    // class Calculator: IAdd, ISubtract, ICalculator : Multiple interface implementation
    //class Calculator : ICalculator                   //Icaculator inherit from iadd interface and isubtract interface
    class Calculator : ICalculator
    {

        public int subtract(int a, int b)
        {
            return a - b;
        }
        public float division(float a, float b)
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
         
        public int add(int a, int b)
        {
            return a + b;
        }

    }
}
