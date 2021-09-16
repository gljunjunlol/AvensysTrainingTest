using System;
using ConsoleApp2;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            int res = class1.add(3, 4);

            if(res <= 7)
            {
                Console.WriteLine("result is less than 7");
            }
            else
            {
                Console.WriteLine("result is more than 7");
            }

            res = res * 2;
            res = res + 1;
            class1.privateprint();
            Console.WriteLine(res);
            Console.ReadLine();

            

             
        }
    }
}
