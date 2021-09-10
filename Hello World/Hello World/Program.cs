using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World " + args[0]);
            string str = Subtract(int.Parse(args[1]), int.Parse(args[2])).ToString();
            Console.WriteLine("The subtraction of two numbers is: " + str);
            Console.ReadLine();


        }

        private static int Subtract(int a, int b)

        {
            return a - b;
        }

    }
}
