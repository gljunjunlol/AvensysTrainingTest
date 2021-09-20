using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desctructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Example e1 = new Example();

            e1.SetValue(2, 3);

            e1.DisplayValue();

            Console.ReadLine();
        }
    }
}
