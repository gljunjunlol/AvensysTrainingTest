using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_4
{
    class Calculator
    {
        public static void subtract(int a, int b)
        {
            Console.WriteLine("The subtraction of calculated " + (a - b));
 
        }
        public static void division(int a, int b)
        {
            try
            {
                Console.WriteLine("The division of calculated " + (a / b));
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("divde by zero exception caught");
                throw ex;
            }



        }

        public static void Modululo(int a, int b)
        {
            try
            {
                Console.WriteLine("The modulus of calculated " + (a % b));
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("divde by zero exception caught");
                throw ex;
            }
            
        }

        public static void multiply(int a, int b)
        {
            Console.WriteLine("The multiply of calculated " + (a * b));
        }

        public static void Add(int a, int b)
        {
            Console.WriteLine("The add of calculated " + (a + b));
        }
        public static void Power(int a, int b)
        {
            Console.WriteLine("The Power of calculated " + (Math.Pow(a, b)));
        }
    }
}
