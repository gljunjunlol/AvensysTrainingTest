using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    delegate void delcalculator(int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            delcalculator anonymousCalculator = (int i, int j) => { Console.WriteLine("Input num" + (i, j)); };

            Console.WriteLine("Enter two numbers");
            var a = Int32.Parse(Console.ReadLine());
            var b = Int32.Parse(Console.ReadLine());

            Calculator calculateAll = new Calculator();

            DelCalculate del = new DelCalculate(calculateAll.add);
            DelCalculate del1 = new DelCalculate(calculateAll.subtract);
            DelCalculate del2 = new DelCalculate(calculateAll.multiply);
            DelCalculate del3 = new DelCalculate(calculateAll.division);

            Operation.performOperation(a, b, del);
            Operation.performOperation(a, b, del1);
            Operation.performOperation(a, b, del2);
            Operation.performOperation(a, b, del3);

            Console.ReadLine();



            //calculateAll.add(5, 4);
            //calculateAll.add(5, 4);
            //calculateAll.add(5, 4);

            //calculateAll.multiply(5, 4);
            //calculateAll.multiply(5, 4);
            //calculateAll.multiply(5, 4);

            //calculateAll.subtract(5, 4);
            //calculateAll.subtract(5, 4);
        }
    }
}
