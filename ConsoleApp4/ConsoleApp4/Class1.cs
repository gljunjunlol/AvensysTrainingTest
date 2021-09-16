using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public abstract class Class1
    {
        public abstract void p1();

    }
    public class Child : Class1         // need to put abstract here
    {
        public override void p1()
        {
            Console.WriteLine("p1 method");
        }
    }


    enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}


