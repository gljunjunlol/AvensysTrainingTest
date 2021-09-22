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
            Calculator calculate = new Calculator();
            

            Console.WriteLine("Enter two numbers");
            var a = Int32.Parse(Console.ReadLine());
            var b = Int32.Parse(Console.ReadLine());

            DelCalculate testDelA = (i, j) => { Console.WriteLine("In anonymous method add:  " + (a + b)); };
            DelCalculate testDelB = (i, j) => { Console.WriteLine("In anonymous method sub:  " + (a - b)); };
            DelCalculate testDelC = (i, j) => { Console.WriteLine("In anonymous method mul:  " + (a * b)); };
            DelCalculate testDelD = (i, j) => { Console.WriteLine("In anonymous method div:  " + (a / b)); };

            testDelA(a, b);
            testDelB(a, b);
            testDelC(a, b);
            testDelD(a, b);

            Calculator calculateAll = new Calculator();

            //DelCalculate del = new DelCalculate(calculateAll.add);
            //DelCalculate del1 = new DelCalculate(calculateAll.subtract);
            //DelCalculate del2 = new DelCalculate(calculateAll.multiply);
            //DelCalculate del3 = new DelCalculate(calculateAll.division);

            //Operation.performOperation(a, b, del);
            //Operation.performOperation(a, b, del1);
            //Operation.performOperation(a, b, del2);
            //Operation.performOperation(a, b, del3);

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
