using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudioDemo
{
    public class Class1
    {
        int a;                  // DEFAULT IS INTERNAL (ACCESS MODIFIER)
        int b;
        int c;
        const int f = 5;          // const means complier wont allow you to set c = something else (e.g. pi value)
        readonly int d;              //  readonly once assigned in constructor, cannot change already (e.g. bank interest)

        public int e { get; set; }       // PROPERTIES
        public string address { get; set; }

        public void displayValue()
        {
            e = 5;
            Console.WriteLine(e);
        }

        // DEFAULT CONSTRUCTOR
        public Class1()
        {
            Console.WriteLine("Creating instance of class 1 usng default constructor");

        }

        // PARAMETERISED CONSTRUCTOR
        public Class1(int a1, int b, int c)
        {
            Console.WriteLine("creating instance of class 1 using param constructor");
            a = a1;
            this.b = b;
            this.c = c;
        }
        // OVERRIDDING - e.g. overriding for parameterised constructor
        public Class1(float a1, int b, int c)
        {
            Console.WriteLine("creating instance of class 1 using param constructor");
        }

        // STATIC CONSTRUCTOR
        static Class1()             
        {
            Console.WriteLine("Creating instance of class 1 using static constructor");
        }

        public static void dosomething()
        {
            Console.WriteLine("Print in do somethng");
        }

        public void printall(int i, int j, int k = -5)                 // int k = -5 optional parameter (need to fill from right if optional parameter)
        {
            Console.WriteLine("in print all");
            Console.WriteLine("i :" + i);
            Console.WriteLine("j :" + j);
            Console.WriteLine(" k: " + k);

            Console.WriteLine("e: " + e);
        }

        //public void printall(int i, int j)             // OVERRIDING if print all put 2 param only, this method will be called 1st
        //{
        //    Console.WriteLine("in print all with only 2 param");
        //    Console.WriteLine("i :" + i);
        //    Console.WriteLine("j :" + j);
        //}

        public void setA(int a)
        {
            this.a = a;
        }

        public void setB(int b)
        {
            this.b = b;
        }
        public void setC(int c)
        {
            this.c = c;
        }
        public int add()
        {
            print();
            return a + b + c;
        }

        internal void print()
        {

        }

        
    }
}
