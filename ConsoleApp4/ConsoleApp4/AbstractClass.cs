using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceDemo
{
    
    abstract class abstractexample
    {
        int a = 5;
        protected int b = 10;

        public void printa()
        {
            Console.WriteLine("Value of a :" + a);
        }

        public virtual void printb()
        {
            Console.WriteLine("Value of b : " + b);
        }
    }

    class sample : abstractexample
    {
        int b = 20;


        public override void printb()
        {
            Console.WriteLine("Value of abstract example b : " + base.b);
        }
    }
    class sample2 : abstractexample
    {

    }
    class AbstractClassExample
    {
        public static void Main()
        {
            //Static class example
            //example.ex();

            //Abstract class example
            sample s = new sample();
            s.printa();
            s.printb();

            sample2 s2 = new sample2();
            s2.printa();
            s2.printb();

            Console.Read();
        }
    }
}