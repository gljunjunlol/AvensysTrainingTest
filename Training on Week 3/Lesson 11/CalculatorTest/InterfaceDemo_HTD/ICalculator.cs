using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo_HTD
{
    interface ICalculator      // interface inheritance
    {
        int add(int a, int b);
        int subtract(int a, int b);

        int multiply(int a, int b);

        float division(float a, float b);

        int Modululo(int a, int b);
    }
}
