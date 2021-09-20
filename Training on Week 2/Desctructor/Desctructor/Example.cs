using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desctructor
{
    class Example
    {
        int number1, number2;
        public Example()
        {
            Console.WriteLine("Default constructor was called");
            number1 = 0;
            number2 = 0;
        }

        public void SetValue(int num1, int num2)
        {
            number1 = num1;
            number2 = num2;
        }
    
        public void DisplayValue()
        {
            Console.WriteLine("Number 1 = " + number1);
            Console.WriteLine("Number 2 = " + number2);
        }

        ~Example()
        {
            Console.WriteLine("Destructor was called");     // or also finaliser
            Console.ReadLine();

        }
    }
}
