using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class employee
    {
        int x, y;
        double f;
        string s;
        public employee(int a, float b)
        {
            x = a;
            f = b;
        }
        public employee(int a, string b)
        {
                y = a;
                s = b;
        }

        static employee()
        {
            Console.WriteLine("this is a static constructor");
        }

        private employee()
        {
            Console.WriteLine("this is private constructor");
        }
        public void show()
        {
            Console.WriteLine("first constructor (int + float): {0} ", (x + f));
        }

        public void show1()
        {
            Console.WriteLine("second constructor (int + string): {0} ", (y + s));
        }
    }
    
}

