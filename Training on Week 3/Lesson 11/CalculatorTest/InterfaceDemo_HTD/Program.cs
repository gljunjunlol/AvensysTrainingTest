using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo_HTD
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Console.WriteLine("Add : " + calc.add(3, 4));

            Console.WriteLine("Enter first number: ");
            int input1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int input2 = Int32.Parse(Console.ReadLine());
            ICalculator calculator = new Calculator();
            Console.WriteLine("Add :" + calculator.add(input1, input2));
            Console.WriteLine("Sub :" + calculator.subtract(input1, input2));
            Console.WriteLine("Mul :" + calculator.multiply(input1, input2));
            Console.WriteLine("Div :" + calculator.division(input1, input2));
            Console.WriteLine("Mod :" + calculator.Modululo(input1, input2));

            Console.ReadLine();
        }
    }
}
