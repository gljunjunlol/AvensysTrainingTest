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
            Console.WriteLine("Add : " + calc.Add(3, 4));

            IAdd add = new Calculator();
            Console.WriteLine("ADD: " + calc.Add(3, 4));

            IAddDuplicate addDuplicate = new Calculator(); ;
            Console.WriteLine("Add : " + addDuplicate.Add(3, 4));
            //Console.WriteLine("Sub : " + calc.subtract(3, 4));
            //Console.WriteLine("Mul : " + calc.multiply(3, 4));
            //Console.WriteLine("Div : " + calc.division(3, 4));
            //Console.WriteLine("Mod : " + calc.Modululo(3, 4));

            //// interface boxing - to check which method can be called

            //ICalculator calculator = new Calculator();
            //Console.WriteLine("Add :" + calculator.Add(3, 4));
            //Console.WriteLine("Sub :" + calculator.subtract(3, 4));
            //Console.WriteLine("Mul :" + calculator.multiply(3, 4));
            //Console.WriteLine("Div :" + calculator.division(3, 4));
            //Console.WriteLine("Mod :" + calculator.Modululo(3, 4));
            //Console.WriteLine("Add :" + calculator.bitwiseAnd(3, 4));

            Console.ReadLine();
        }
    }
}
