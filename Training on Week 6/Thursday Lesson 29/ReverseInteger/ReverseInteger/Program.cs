using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Key in number");
            int input2 = Int32.Parse(Console.ReadLine());
            p.ReverseNumber(input2);

            Console.ReadLine();
        }
        private int ReverseNumber(int number)
        {
            int reversed = 0;
            while (number != 0)
            {
                int rem = number % 10;    // remove the last digit from number
                number = number / 10;
                reversed = checked(reversed * 10 + rem); // check for overflow && info, ones column becomes the tens column, the tens column becomes the hundreds column
            }
            Console.WriteLine("Reverse no : " + reversed);
            return reversed;

            
        }
    }
}
