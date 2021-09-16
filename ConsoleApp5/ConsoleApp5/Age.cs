using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{

    class Age
    {
        int a, b;

        public Age()
        {
            Console.WriteLine("Default");
        }
        public Age(int a, int b)
        {
            Console.WriteLine("");
        }
        public Age(int a, double b)
        {
            Console.WriteLine("");
        }

        public void show()
        {
            Console.WriteLine("First one: " + a + b);
        }

        public void show2()
        {
            Console.WriteLine("2nd one: " + a + b);
        }
    }
}
