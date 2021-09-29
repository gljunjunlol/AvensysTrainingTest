using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class TakeAnyFunction
    {
        public int doSomething(string input)
        {
            Console.WriteLine("return do something method");
            return 50;
        }
        public int doSomething2(int input)
        {
            return 100;
        }

        public bool RunMethod (Func<string, int> Methodname)
        {
            Console.WriteLine("return run method");
            int i = Methodname("go to do something method");

            return true;
        }

        public bool Test()
        {
            Console.WriteLine("go to run method");
            return RunMethod(doSomething);
            
        }

    }
}
