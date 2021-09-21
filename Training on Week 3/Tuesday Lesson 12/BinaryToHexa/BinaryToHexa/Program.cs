using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryToHexa
{
    class Program
    {
        static void Main(string[] args)
        {
            // to binary

            Console.Write("Enter any Integer to check for its Binary + Hexadecimal: ");
            int Number = int.Parse(Console.ReadLine());
            int Number2 = Number;
            int remainder;
            string result = string.Empty;
            while (Number > 0)
            {
                remainder = Number % 2;
                Number /= 2;
                result = remainder.ToString() + result;
            }
            Console.WriteLine("The Converted Binary number seen:  {0}", result);

            Console.ReadLine();

            Dictionary<int, char> dict = new Dictionary<int, char>()
            {
                {10, 'A' },
                {11, 'B' },
                {12, 'C' },
                {13, 'D' },
                {14, 'E' },
                {15, 'F' },
            };

            List<object> remainders2 = new List<object>();
            int remainder2;
            string result2 = string.Empty;
            while (Number2 > 0)
            {
                remainder2 = Number2 % 16;
                Number2 /= 16;


                if (dict.ContainsKey(remainder2))
                {
                    remainders2.Add(dict[remainder2]);
                }
                else
                {
                    remainders2.Add(remainder2);
                }

                remainders2.Add(result2);




            }
            remainders2.Reverse();
            Console.WriteLine("The Converted Hexadecimal number seen:  {0}", string.Join("", remainders2));

            Console.ReadLine();
        }
    }
}
