using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo_HTD
{
    interface ICalculator : IAdd, ISubtract       // interface inheritance
    {
        int multiply(int a, int b);

        int division(int a, int b);

        int Modululo(int a, int b);
    }
}
