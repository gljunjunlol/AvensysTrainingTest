using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using NamespaceDemo.Parent;

namespace NamespaceDemo
{

    struct structexample
    {
        int a;
        int b;
        long c;
    }

    //class parent { }

    //class child : parent { }

    //class example { }

    class Program
    {
        static void Main(string[] args)
        {

            //-2,147,483,647 to 2,147,483,647

            checked                 // checked will help show an exception
            {
                int a = Int32.MaxValue;
                Console.WriteLine("Value of a: " + a);
                a++;
                Console.WriteLine("value of a: " + a);
                Console.Read();
            }
            


            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

            Console.Read();
            parent p = new parent();
            child ch = new child();
            example ex = new example();

            Console.WriteLine(p is object);   // True         // if can be converted or not p to object
            Console.WriteLine(p is child);       // False
            Console.WriteLine(p is example);    // False
             
            Console.WriteLine(ch is object);      // True
            Console.WriteLine(ch is parent);         // True
            Console.WriteLine(ch is example);      // False

            Console.WriteLine(ex is object);      //True
            Console.WriteLine(ex is parent);      //False
            Console.WriteLine(ex is child);        // False



            //ParentClass pc = new ParentClass();

            //a pc = new a();
            //pc.print();
            //Console.ReadLine();

            //SizeOf operator
            int i = 5;
            int[] arr = new int[10];
            structexample ex = new structexample();

            Console.WriteLine("len of arr : " + arr.Length);
            Console.WriteLine("size of arr in mem: " + arr.Length*sizeof(int));
            Console.WriteLine("int : " + sizeof(int));
            Console.WriteLine("long : " + sizeof(long));
            Console.WriteLine("char : " + sizeof(char));
            Console.WriteLine("double : " + sizeof(double));
            Console.ReadKey();

            // as operator (only work with reference type conversion)
            a ainstance = new a();

            string str1 = "Session";
            object obj = "sessionobject";

            var n = str1 as object;
            var m = obj as string;

            object conva = ainstance as object;
            b conva1 = conva as b;    // converting


            if (n!= null)
            {
                Console.WriteLine("Sucessfully converted str1");
            }
            if (m != null)
            {
                Console.WriteLine("convereted obj");
            }
            else
            {
                Console.WriteLine("conversion failed for obj");
            }

            if(conva is b)
            {
                //b conva1 = conva as b;
                Console.WriteLine("can be convereted to b");
            }
            else
            {
                Console.WriteLine("can be convereted to b");
            }
            if(conva is a conva1)
            {
                conva1.print();
                Console.WriteLine("can be converted to a");
            }
            Console.Read();


        }
    }
}

namespace NamespaceDemo.Parent
{
    class a
    {
        void print()
        {
            Console.WriteLine("in parent namespace");
        }
    }

    class b
    {

    }

    class PrivateParentClass
    {
        void print()
        {
            Console.WriteLine("in private parent class namspace");
        }
    }
}

namespace NamespaceDemo.Parent.Child
{
    class a
    {
        public void print()
        {
            Console.WriteLine("in child namespace");
        }
        
    }
}