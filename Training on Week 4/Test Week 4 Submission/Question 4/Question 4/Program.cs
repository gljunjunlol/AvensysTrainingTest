using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Question_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Key in first number");
            int input1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Key in second number");
            int input2 = Int32.Parse(Console.ReadLine());
            try
            {
                new Thread(() => { Calculator.Add(input1, input2); }).Start();

                new Thread(() => { Calculator.subtract(input1, input2); }).Start();

                new Thread(() => { Calculator.Modululo(input1, input2); }).Start();

                new Thread(() => { Calculator.multiply(input1, input2); }).Start();

                new Thread(() => { Calculator.Power(input1, input2); }).Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception caught");
            }

            




            Console.ReadLine();
        }
    }
}
