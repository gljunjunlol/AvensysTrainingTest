using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = { "i love programming very much" };              // Question 4 reverse the string
            str.Split();
            Array.Reverse(str);
            Console.WriteLine(string.Join(" ", str));
            Console.ReadLine();
        }
    }
}
