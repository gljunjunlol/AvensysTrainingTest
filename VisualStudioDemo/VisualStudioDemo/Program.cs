using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudioDemo
{
    class Parent
        {
        static Parent()
        {
            Console.WriteLine("In static constructor of parent");                  // static constructor call child 1st
        }
        public Parent()
    {
        Console.WriteLine("In constructor of parent");
    }
        
        }
    class Child : Parent
    {
        public Child()
        {
                Console.WriteLine("In constructor of child");
            }

        public void print()
        {
            Console.WriteLine("");
        }
    
    }
    class grandChild : Child
    {
        public grandChild()
        {
            base.print();                                        // e.g. to print from parent  base
            Console.WriteLine("In constructor of grandchild");
        }        

        public void print()                             // can use public override, public virtual           
        {
            Console.WriteLine("");
        }
    }

    class indexerExample                // example of index
    {
        private int[] sampletype = new int[10];

        public int this [int i]
        {
            get
            {
                return sampletype[i];
            }
            set
            {
                sampletype[i] = value;
            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {

            // order of calling, 1st is static constructor, 2nd is parametrised, 3rd is default constructor..




            Class1 class1 = new Class1(3, 14, 12);              // 1st way parameterised constructor
            int res = class1.add();                         // 1st way parameterised constructor
            Console.WriteLine("result " + res);             // 1st way parameterised constructor

            class1.displayValue();     // properties

            Class1 class1instance = new Class1();               // 2nd way parameterised constructor using setA, setB, setC method
            class1instance.setA(1);                             // 2nd way parameterised constructor            
            class1instance.setB(8);                            // 2nd way parameterised constructor             
            class1instance.setC(16);                                // 2nd way parameterised constructor
            int res1 = class1instance.add();                      // 2nd way parameterised constructor
            Console.WriteLine("result1 " + res1);                   // 2nd way parameterised constructor


            //Parent p = new Parent();                 // to call parent class
            Child c = new Child();

            //grandChild gc = new grandChild();


            Child c1 = new grandChild();                               // e.g. child from grandchild
            c1.print();                          // will print grand child print                   unless you put Override there in grandchild print


            Class1.dosomething();           // from static constructor



            //indexerExample id = new indexerExample();
            //id[0] = 1;
            //id[1] = 1;
            //id[2] = 1;
            //id[3] = 1;
            //id[4] = 1;
            //id[5] = 1;

            //for(int i =0; i < 5; i++)
            //{
            //    Console.WriteLine(id[i]);
            //}
            Class1 c1 = new Class1 { e = 5 };     // properties
            c1.printall(1, 2);                    // value of e, properties



            class1instance.printall(10, 20);

            //class1instance.printall(j:10, i:20);             //name parameters e.g. j:10 , i:20

            Console.Read();
        }
    }
}
