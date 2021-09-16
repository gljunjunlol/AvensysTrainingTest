using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Class1
    {
        public int add(int a, int b)
        {
            print();
            return a + b;
        }
        internal void print()
        {
            privateprint();
            System.Console.WriteLine("This is internal");
        }

        public void privateprint()
        {
            var temp = Environment.StackTrace;
            Console.WriteLine("Do something");
        }
    }
}
