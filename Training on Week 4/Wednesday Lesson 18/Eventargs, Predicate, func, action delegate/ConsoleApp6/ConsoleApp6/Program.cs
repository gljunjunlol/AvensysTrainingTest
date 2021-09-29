using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher p = new Publisher();
            p.numberModifiedEvent += P_numberModifiedEvent;
            Console.WriteLine("key any number");
            int dividend = Int32.Parse(Console.ReadLine());
            Console.WriteLine("key divisor number");
            int divisor = Int32.Parse(Console.ReadLine());
            p.doSmething(dividend, divisor);
            try
            {
                Func_Example(10, 20);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Two operands cannot be same");
            }
            
            Array arr = new Array();
            arr.Predicate_Example();
            Console.ReadLine();

            TakeAnyFunction take = new TakeAnyFunction();
            take.Test();
            Console.ReadLine();
        }

        private static void P_numberModifiedEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine($"Modified data is {e.someIntProperty} {e.someIntProperty2}");
        }

        private static void Func_Example(int a, int b)
        {
            Console.WriteLine("Enter first no: ");
            int input1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter second no: ");
            int input2 = Int32.Parse(Console.ReadLine());
            Func<int, int, int> func = sum;    // except the last, all are inputs
 
            if ( input1 != input2)
            {
                Console.WriteLine("Ok the numbers are different");
            }
            else
            {
                throw new SameNumberException(a, b);
            }


            Console.WriteLine(func(input1, input2));
            Console.WriteLine("Value of a is: " + input1);
            Console.WriteLine("Value of b is: " + input2);

            Console.ReadLine();
        }
        public static int sum(int a, int b)
        {
            return a + b;
        }
    }
    class Array
    {
        public void Predicate_Example()
        {
            Predicate<string> predicate = (str) =>
            {
                string[] array1 = new string[10] { "hello", "this", "is", "a", "sentence", "word", "that", "i", "come", "up", };
                Console.WriteLine("Enter a word");
                string input1 = Console.ReadLine();
                if (array1.Contains(input1))
                {
                    return true;
                }
                return false;
            };
            Console.WriteLine(predicate("str"));

        }
            


        
    }
}
