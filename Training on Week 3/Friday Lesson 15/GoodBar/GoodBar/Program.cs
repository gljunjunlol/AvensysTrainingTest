using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodBar
{
    class Program
    {
        static void Main(string[] args)
        {
            Bar bar = new Bar();

            BarCustomer b1 = new BarCustomer(19, "Steven", true, "cash");
            BarCustomer b2 = new BarCustomer(15, "Stevenson", true, "card");
            BarCustomer b3 = new BarCustomer(26, "Mary", false, "card");
            BarCustomer b4 = new BarCustomer(32, "Steven JR", true, "card");
            BarCustomer b5 = new BarCustomer(25, "Marpherson", true, "card");


            bar.EnterToGoodBar(b1);
            bar.EnterToGoodBar(b2);
            bar.EnterToGoodBar(b3);
            bar.EnterToGoodBar(b4);
            bar.EnterToGoodBar(b5);


            Console.ReadLine();
        }
    }
}
